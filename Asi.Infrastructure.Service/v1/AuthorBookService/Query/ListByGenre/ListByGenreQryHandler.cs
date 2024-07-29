using Asi.Application.Repository.V1;
using Asi.Domain.Model.V1.AuthorVM;
using Asi.Domain.Model.V1.BookVM;
using MediatR;

namespace Asi.Infrastructure.V1.AuthorBookService.Query.ListByGenre
{
    public class ListByGenreQryHandler : IRequestHandler<ListByGenreQry, IEnumerable<Book>>
    {
        private readonly IGenericRepository<Author> _authorRepository;
        private readonly IGenericRepository<Book> _bookRepository;

        public ListByGenreQryHandler(IGenericRepository<Author> authorRepository, IGenericRepository<Book> bookRepository)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<Book>> Handle(ListByGenreQry request, CancellationToken cancellationToken)
        {
            return await _bookRepository.GetAllAsync(s => s.Genre == request.genre);
        }
    }
}
