using Asi.Application.Repository.V1;
using Asi.Domain.Model.V1.AuthorVM;
using Asi.Domain.Model.V1.BookVM;
using MediatR;

namespace Asi.Infrastructure.V1.AuthorBookService.Query.ListByAuthor
{
    public class ListByAuthorQryHandler : IRequestHandler<ListByAuthorQry, IEnumerable<Book>>
    {
        private readonly IGenericRepository<Author> _authorRepository;
        private readonly IGenericRepository<Book> _bookRepository;

        public ListByAuthorQryHandler(IGenericRepository<Author> authorRepository, IGenericRepository<Book> bookRepository)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<Book>> Handle(ListByAuthorQry request, CancellationToken cancellationToken)
        {
            var author = _authorRepository.GetById(request.authorId);

            if (author is null)
            {
                throw new Exception("Author not found");
            }

            return await _bookRepository.GetAllAsync(s => s.AuthorId == request.authorId);
        }
    }
}
