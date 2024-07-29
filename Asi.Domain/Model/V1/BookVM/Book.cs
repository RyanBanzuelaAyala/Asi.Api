using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asi.Domain.Model.V1.BookVM
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Genre { get; set; }

        public int AuthorId { get; set; }

    }
}
