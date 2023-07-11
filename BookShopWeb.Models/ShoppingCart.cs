using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BookShopWeb.Models
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }

        public int BookId { get; set; }

        [ValidateNever]
        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        public string ApplicationUserId { get; set; }

        [ValidateNever]
        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser ApplicationUser { get; set; }

        [NotMapped]
        public decimal TotalListPrice { get; set; }
    }
}
