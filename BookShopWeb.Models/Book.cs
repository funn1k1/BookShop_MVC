using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Display(Name = "Cover Image URL")]
        [DataType(DataType.ImageUrl)]
        public string? CoverImageUrl { get; set; }

        [Display(Name = "Available Quantity")]
        [Range(0, int.MaxValue)]
        public int AvailableQuantity { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
    }
}
