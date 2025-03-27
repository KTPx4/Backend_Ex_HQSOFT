using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BookStore.DTOs
{
    public class UpdateAuthorModel
    {
        [Required]
        public int AuthorId { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [AllowNull, MaxLength(500)]
        public string Bio { get; set; }
    }
}
