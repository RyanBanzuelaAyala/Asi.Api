using Asi.Application.Repository.V1;
using Asi.Domain.Model.V1.AuthorVM;
using Asi.Domain.Model.V1.BookVM;
using MediatR;

namespace Asi.Infrastructure.V1.AuthorBookService.Command.CreateBookWithAuthor
{
    public class CreateBookWithAuthorCmdHandler : IRequestHandler<CreateBookWithAuthorCmd, Book>
    {
        private readonly IGenericRepository<Author> _authorRepository;
        private readonly IGenericRepository<Book> _bookRepository;

        public CreateBookWithAuthorCmdHandler(IGenericRepository<Author> authorRepository, IGenericRepository<Book> bookRepository)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
        }

        public async Task<Book> Handle(CreateBookWithAuthorCmd request, CancellationToken cancellationToken)
        {

            var author = _authorRepository.GetById(request.authorId);

            if (author is null)
            {
                throw new Exception("Author not found");
            }

            _bookRepository.Add(request.book);

            return request.book;

        }
    }
}
