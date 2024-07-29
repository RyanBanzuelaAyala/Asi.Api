using Asi.Domain.Model.V1.AuthorVM;
using Asi.Domain.Model.V1.BookVM;
using Asi.Infrastructure.Service.V1.AuthorService.Command.UpdateBookDetails;
using Asi.Infrastructure.V1.AuthorBookService.Command.CreateAuthor;
using Asi.Infrastructure.V1.AuthorBookService.Command.CreateBookWithAuthor;
using Asi.Infrastructure.V1.AuthorBookService.Command.RemoveBookFromAuthor;
using Asi.Infrastructure.V1.AuthorBookService.Command.UpdateBookDetails;
using Asi.Infrastructure.V1.AuthorBookService.Query.ListByAuthor;
using Asi.Infrastructure.V1.AuthorBookService.Query.ListByGenre;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Asi.Infrastructure.Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AsiServiceInfraService(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<CreateAuthorCmd, Author>, CreateAuthorCmdHandler>();
            services.AddTransient<IRequestHandler<CreateBookWithAuthorCmd, Book>, CreateBookWithAuthorCmdHandler>();
            services.AddTransient<IRequestHandler<RemoveBookFromAuthorCmd, Book>, RemoveBookFromAuthorCmdHandler>();
            services.AddTransient<IRequestHandler<UpdateBookDetailsCmd, Book>, UpdateBookDetailsCmdHandler>();

            services.AddTransient<IRequestHandler<ListByAuthorQry, IEnumerable<Book>>, ListByAuthorQryHandler>();
            services.AddTransient<IRequestHandler<ListByGenreQry, IEnumerable<Book>>, ListByGenreQryHandler>();

            return services;
        }
    }
}
