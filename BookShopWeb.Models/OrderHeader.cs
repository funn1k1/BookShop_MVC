using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BookShopWeb.Models
{
    public class OrderHeader
    {
        [Key]
        public int Id { get; set; }

        public string ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }

        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        public DateTime ShippingDate { get; set; }

        [Display(Name = "Total")]
        public decimal OrderTotal { get; set; }

        [Display(Name = "Order Status")]
        public string? OrderStatus { get; set; }

        public string? SessionId { get; set; }

        [Display(Name = "Payment Status")]
        public string? PaymentStatus { get; set; }

        [Display(Name = "Tracking Number")]
        public string? TrackingNumber { get; set; }

        public string? Carrier { get; set; }

        [Display(Name = "Payment Date")]
        public DateTime PaymentDate { get; set; }

        public string? PaymentIntentId { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        [Display(Name = "Postal Code")]
        public int PostalCode { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
