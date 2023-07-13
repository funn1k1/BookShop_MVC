using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BookShopWeb.Models
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }

        public int OrderHeaderId { get; set; }

        [ForeignKey("OrderHeaderId")]
        [ValidateNever]
        public string OrderHeader { get; set; }

        public int BookId { get; set; }

        [ForeignKey("BookId")]
        [ValidateNever]
        public Book Book { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
