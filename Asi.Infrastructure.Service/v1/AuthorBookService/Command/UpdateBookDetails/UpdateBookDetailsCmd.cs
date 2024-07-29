using Asi.Domain.Model.V1.BookVM;
using MediatR;

namespace Asi.Infrastructure.V1.AuthorBookService.Command.UpdateBookDetails
{
    public class UpdateBookDetailsCmd : IRequest<Book>
    {
        public Book book { get; set; }
    }
}