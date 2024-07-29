using Asi.Application.Repository.V1;
using Asi.Domain.Model.V1.BookVM;
using MediatR;

namespace Asi.Infrastructure.V1.AuthorBookService.Command.RemoveBookFromAuthor
{
    public class RemoveBookFromAuthorCmdHandler : IRequestHandler<RemoveBookFromAuthorCmd, Book>
    {
        private readonly IGenericRepository<Book> _bookRepository;

        public RemoveBookFromAuthorCmdHandler(IGenericRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> Handle(RemoveBookFromAuthorCmd request, CancellationToken cancellationToken)
        {
            var book = _bookRepository.GetById(request.bookId);

            if (book is null)
            {
                throw new Exception("Book not found");
            }

            book.AuthorId = 0;

            _bookRepository.Update(book);

            return book;
        }
    }
}
