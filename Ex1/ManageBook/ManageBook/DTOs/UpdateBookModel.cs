using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookStore.DTOs
{
    public class UpdateBookModel
    {
        [Required]
        public int BookId { get; set; }

        [Required, MaxLength(200)]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [Required]
        public int AuthorId { get; set; }

        [Required]
        public DateTime? PublishedDate { get; set; }
    }
}
