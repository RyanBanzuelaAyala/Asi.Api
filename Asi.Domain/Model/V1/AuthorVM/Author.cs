using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asi.Domain.Model.V1.AuthorVM
{
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? Name { get; set; }

        //public List<Book> Books { get; set; } = new List<Book>();

    }
}
