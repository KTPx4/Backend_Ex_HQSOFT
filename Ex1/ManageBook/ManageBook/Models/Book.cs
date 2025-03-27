using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ManageBook.Models
{
    [Table("Books")]
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

        [Required, MaxLength(200)]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        [JsonIgnore] // Ngăn vòng lặp khi serialize JSON
        public Author Author { get; set; }

        public DateTime? PublishedDate { get; set; }
    }
}
