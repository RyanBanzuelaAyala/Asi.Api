using Asi.Application.Repository.V1;
using Asi.Domain.Model.V1.BookVM;
using Asi.Infrastructure.V1.AuthorBookService.Command.UpdateBookDetails;
using MediatR;

namespace Asi.Infrastructure.Service.V1.AuthorService.Command.UpdateBookDetails
{
    public class UpdateBookDetailsCmdHandler : IRequestHandler<UpdateBookDetailsCmd, Book>
    {
        private readonly IGenericRepository<Book> _bookRepository;

        public UpdateBookDetailsCmdHandler(IGenericRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> Handle(UpdateBookDetailsCmd request, CancellationToken cancellationToken)
        {
            _bookRepository.Update(request.book);

            return request.book;
        }
    }
}
