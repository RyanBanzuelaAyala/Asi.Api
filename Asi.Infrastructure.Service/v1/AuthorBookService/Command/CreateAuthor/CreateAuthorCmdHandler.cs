using Asi.Application.Repository.V1;
using Asi.Domain.Model.V1.AuthorVM;
using MediatR;

namespace Asi.Infrastructure.V1.AuthorBookService.Command.CreateAuthor
{
    public class CreateAuthorCmdHandler : IRequestHandler<CreateAuthorCmd, Author>
    {
        private readonly IGenericRepository<Author> _authorRepository;

        public CreateAuthorCmdHandler(IGenericRepository<Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Author> Handle(CreateAuthorCmd request, CancellationToken cancellationToken)
        {

            _authorRepository.Add(request.author);

            return request.author;

        }
    }
}
