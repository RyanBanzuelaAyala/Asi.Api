using Asi.Domain.Model.V1.BookVM;
using MediatR;

namespace Asi.Infrastructure.V1.AuthorBookService.Command.CreateBookWithAuthor
{
    public class CreateBookWithAuthorCmd : IRequest<Book>
    {
        public int authorId { get; set; }
        public Book book { get; set; }

    }
}