using Asi.Domain.Model.V1.BookVM;
using MediatR;

namespace Asi.Infrastructure.V1.AuthorBookService.Query.ListByGenre
{
    public class ListByGenreQry : IRequest<IEnumerable<Book>>
    {
        public string genre { get; set; }
    }
}