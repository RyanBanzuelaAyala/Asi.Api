using Asi.Domain.Model.V1.AuthorVM;
using MediatR;

namespace Asi.Infrastructure.V1.AuthorBookService.Command.CreateAuthor
{
    public class CreateAuthorCmd : IRequest<Author>
    {
        public Author author { get; set; }
    }
}