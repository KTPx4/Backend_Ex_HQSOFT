using ManageBook.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.DTOs
{
    public class CreateBookModel
    {

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
