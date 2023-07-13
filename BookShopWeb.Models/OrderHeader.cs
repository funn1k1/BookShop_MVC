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

        public DateTime OrderDate { get; set; }

        public DateTime ShippingDate { get; set; }

        public decimal OrderTotal { get; set; }

        public string? OrderStatus { get; set; }

        public string? PaymentStatus { get; set; }

        public string? TrackingNumber { get; set; }

        public string? Carrier { get; set; }

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
