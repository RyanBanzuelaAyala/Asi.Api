using Asi.Domain.Model.V1.BookVM;
using MediatR;

namespace Asi.Infrastructure.V1.AuthorBookService.Query.ListByAuthor
{
    public class ListByAuthorQry : IRequest<IEnumerable<Book>>
    {
        public int authorId { get; set; }
    }
}