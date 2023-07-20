using BookShopWeb.DataAccess.Repository.IRepository;
using BookShopWeb.Models;
using BookShopWeb.Models.ViewModels;
using BookShopWeb.Utility;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;

namespace BookShopWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class CartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(string userId)
        {
            var shoppingCarts = _unitOfWork.ShoppingCart.GetAll(c => c.ApplicationUserId == userId, "Book,Book.Category");

            foreach (var shoppingCart in shoppingCarts)
            {
                var bookPrice = shoppingCart.Book.ListPrice;
                shoppingCart.TotalListPrice = bookPrice * shoppingCart.Quantity;
            }

            var shoppingCartVM = new ShoppingCartViewModel
            {
                Items = shoppingCarts,
                OrderHeader = new OrderHeader
                {
                    OrderTotal = shoppingCarts.Sum(c => c.TotalListPrice),
                    ApplicationUserId = userId
                }
            };

            return View(shoppingCartVM);
        }

        public IActionResult UpdateBookQuantity(int cartId, int quantity)
        {
            var book = _unitOfWork.ShoppingCart.Get(c => c.Id == cartId);
            if (book is null)
            {
                return NotFound();
            }

            book.Quantity = quantity;
            _unitOfWork.ShoppingCart.Update(book);
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index), new { userId = book.ApplicationUserId });
        }

        public IActionResult RemoveBook(int cartId)
        {
            var book = _unitOfWork.ShoppingCart.Get(c => c.Id == cartId);
            if (book is null)
            {
                return NotFound();
            }

            _unitOfWork.ShoppingCart.Remove(book);
            _unitOfWork.Save();

            var oldCount = HttpContext.Session.GetInt32("ShoppingCart_Count");
            if (oldCount is not null)
            {
                HttpContext.Session.SetInt32("ShoppingCart_Count", oldCount.GetValueOrDefault() - 1);
            }

            return RedirectToAction(nameof(Index), new { userId = book.ApplicationUserId });
        }

        public IActionResult Checkout(string userId)
        {
            var shoppingCarts = _unitOfWork.ShoppingCart.GetAll(c => c.ApplicationUserId == userId, "Book,Book.Category");
            if (!shoppingCarts.Any())
            {
                return NotFound();
            }

            foreach (var shoppingCart in shoppingCarts)
            {
                var bookPrice = shoppingCart.Book.ListPrice;
                shoppingCart.TotalListPrice = bookPrice * shoppingCart.Quantity;
            }

            var user = _unitOfWork.Users.Get(u => u.Id == userId);

            var shoppingCartVM = new ShoppingCartViewModel
            {
                Items = shoppingCarts,
                OrderHeader = new OrderHeader
                {
                    ApplicationUserId = user?.Id,
                    FullName = user.FullName,
                    Country = user.Country,
                    City = user.City,
                    PostalCode = user.PostalCode,
                    Address = user.Address,
                    OrderTotal = shoppingCarts.Sum(c => c.TotalListPrice)
                }
            };

            return View(shoppingCartVM);
        }

        [HttpPost]
        public IActionResult Checkout(ShoppingCartViewModel shoppingCartVM)
        {
            shoppingCartVM.Items = _unitOfWork.ShoppingCart.GetAll(c => c.ApplicationUserId == shoppingCartVM.OrderHeader.ApplicationUserId, "Book,Book.Category");
            foreach (var cart in shoppingCartVM.Items)
            {
                cart.TotalListPrice = cart.Book.ListPrice * cart.Quantity;
            }

            if (!ModelState.IsValid)
            {
                return View(shoppingCartVM);
            }

            var orderHeader = new OrderHeader
            {
                FullName = shoppingCartVM.OrderHeader.FullName,
                Address = shoppingCartVM.OrderHeader.Address,
                Country = shoppingCartVM.OrderHeader.Country,
                City = shoppingCartVM.OrderHeader.City,
                PostalCode = shoppingCartVM.OrderHeader.PostalCode,
                PhoneNumber = shoppingCartVM.OrderHeader.PhoneNumber,
                OrderDate = DateTime.Now,
                ApplicationUserId = shoppingCartVM.OrderHeader.ApplicationUserId,
                OrderTotal = shoppingCartVM.Items.Sum(c => c.TotalListPrice),
                OrderStatus = OrderStatuses.Pending,
                PaymentStatus = PaymentStatuses.Pending,
            };

            _unitOfWork.OrderHeaders.Add(orderHeader);
            _unitOfWork.Save();

            var domain = "https://localhost:7161";
            var options = new SessionCreateOptions
            {
                SuccessUrl = $"{domain}/customer/cart/orderconfirmation?orderId={orderHeader.Id}",
                CancelUrl = $"{domain}/customer/cart/index?userId={orderHeader.ApplicationUserId}",
                LineItems = new List<SessionLineItemOptions>(),
                Mode = "payment",
            };

            foreach (var cart in shoppingCartVM.Items)
            {
                var lineItem = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = cart.Book.Title,
                            Description = RemoveHtmlTags(cart.Book.Description),
                        },
                        UnitAmountDecimal = cart.Book.ListPrice * 100,
                        Currency = "USD",
                    },
                    Quantity = cart.Quantity,
                };
                options.LineItems.Add(lineItem);
            }

            var service = new SessionService();
            var session = service.Create(options);
            Response.Headers.Add("Location", session.Url);

            _unitOfWork.OrderHeaders.UpdateStripePaymentId(orderHeader.Id, session.Id, session.PaymentIntentId);
            _unitOfWork.Save();

            var orderDetails = new List<OrderDetail>();
            foreach (var shoppingCart in shoppingCartVM.Items)
            {
                var orderDetail = new OrderDetail
                {
                    OrderHeaderId = orderHeader.Id,
                    BookId = shoppingCart.BookId,
                    TotalPrice = shoppingCart.Book.ListPrice * shoppingCart.Quantity,
                    Quantity = shoppingCart.Quantity,
                };
                orderDetails.Add(orderDetail);
            }

            _unitOfWork.OrderDetails.AddRange(orderDetails);
            _unitOfWork.Save();

            return StatusCode(StatusCodes.Status303SeeOther);
        }

        public IActionResult OrderConfirmation(int orderId)
        {
            var orderHeader = _unitOfWork.OrderHeaders.Get(o => o.Id == orderId, "ApplicationUser");
            if (orderHeader is null)
            {
                return NotFound();
            }

            var orderDetails = _unitOfWork.OrderDetails.GetAll(o => o.OrderHeaderId == orderHeader.Id, "Book,Book.Category");
            if (!orderDetails.Any())
            {
                return NotFound();
            }

            var orderVM = new OrderViewModel
            {
                OrderHeader = orderHeader,
                OrderDetails = orderDetails
            };

            var service = new SessionService();
            var session = service.Get(orderHeader.SessionId);

            if (session.PaymentStatus == "paid")
            {
                _unitOfWork.OrderHeaders.UpdateStripePaymentId(orderHeader.Id, session.Id, session.PaymentIntentId);
                _unitOfWork.OrderHeaders.UpdateStatuses(orderHeader.Id, OrderStatuses.Approved, PaymentStatuses.Approved);

                var shoppingCarts = _unitOfWork.ShoppingCart.GetAll(c => c.ApplicationUserId == orderHeader.ApplicationUserId);
                if (shoppingCarts.Any())
                {
                    _unitOfWork.ShoppingCart.RemoveRange(shoppingCarts);
                }
            }

            HttpContext.Session.Clear();
            _unitOfWork.Save();


            return View(orderVM);
        }

        private string RemoveHtmlTags(string html)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            // Remove all HTML tags
            string strippedText = htmlDoc.DocumentNode.InnerText;
            return strippedText;
        }
    }
}
