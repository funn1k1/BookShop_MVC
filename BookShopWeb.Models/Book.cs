using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BookShopWeb.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "ISBN is 13-digits long")]
        public string ISBN { get; set; }

        [Required]
        [Display(Name = "List Price")]
        [Range(0.01, 100000)]
        public decimal ListPrice { get; set; }

        [Display(Name = "Discounted Price")]
        [Range(0.01, 100000)]
        public decimal? DiscountedPrice { get; set; }

        [Display(Name = "Publication Date")]
        [DataType(DataType.Date)]
        public DateTime? PublicationDate { get; set; }

        public IEnumerable<BookImage> BookImages { get; set; }

        [Required]
        [Display(Name = "Available Quantity")]
        [Range(0, int.MaxValue)]
        public int AvailableQuantity { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ValidateNever]
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
    }
}
