using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShopWeb.Models
{
    public class BookImage
    {
        [Key]
        public int Id { get; set; }

        public string CoverImageUrl { get; set; }

        public int BookId { get; set; }

        [ForeignKey("BookId")]
        public Book Book { get; set; }
    }
}
