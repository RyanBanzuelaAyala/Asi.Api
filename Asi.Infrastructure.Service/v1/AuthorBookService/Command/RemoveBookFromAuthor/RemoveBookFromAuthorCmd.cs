using Asi.Domain.Model.V1.BookVM;
using MediatR;

namespace Asi.Infrastructure.V1.AuthorBookService.Command.RemoveBookFromAuthor
{
    public class RemoveBookFromAuthorCmd : IRequest<Book>
    {
        public int bookId { get; set; }
    }
}