using Asi.Base;
using Asi.Domain.Model.V1.AuthorVM;
using Asi.Domain.Model.V1.BookVM;
using Asi.Infrastructure.V1.AuthorBookService.Command.CreateAuthor;
using Asi.Infrastructure.V1.AuthorBookService.Command.CreateBookWithAuthor;
using Asi.Infrastructure.V1.AuthorBookService.Command.RemoveBookFromAuthor;
using Asi.Infrastructure.V1.AuthorBookService.Command.UpdateBookDetails;
using Asi.Infrastructure.V1.AuthorBookService.Query.ListByAuthor;
using Asi.Infrastructure.V1.AuthorBookService.Query.ListByGenre;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Tamm.QApi.Controllers.Product
{
    public class AuthorBookController : AsiController
    {
        public AuthorBookController(IMediator mediator) : base(mediator)
        {
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [HttpPost, Route("CreateAuthor")]
        public async Task<ActionResult<Author>> CreateAuthor([FromBody] Author author)
        {
            try
            {
                var result = await _mediator.Send(new CreateAuthorCmd
                {
                    author = author
                });

                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [HttpPut, Route("CreateBookWithAuthor")]
        public async Task<ActionResult<Book>> CreateBookWithAuthor([FromBody] Book book, int authorId)
        {
            try
            {
                return await _mediator.Send(new CreateBookWithAuthorCmd
                {
                    book = book,
                    authorId = authorId
                });

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [HttpPut, Route("UpdateBookDetails")]
        public async Task<ActionResult<Book>> UpdateBookDetails([FromBody] Book book)
        {
            try
            {
                return await _mediator.Send(new UpdateBookDetailsCmd
                {
                    book = book
                });

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [HttpDelete, Route("RemoveBookFromAuthor")]
        public async Task<ActionResult<Book>> RemoveBookFromAuthor([FromBody] int bookId)
        {
            try
            {
                return await _mediator.Send(new RemoveBookFromAuthorCmd
                {
                    bookId = bookId
                });

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [HttpPost, Route("ListBookByAuthor")]
        public async Task<IEnumerable<Book>> ListBookByAuthor([FromBody] int authorId)
        {
            try
            {
                return await _mediator.Send(new ListByAuthorQry
                {
                    authorId = authorId
                });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [HttpPost, Route("ListBookByGenre")]
        public async Task<IEnumerable<Book>> ListBookByGenre([FromBody] string genre)
        {
            try
            {
                return await _mediator.Send(new ListByGenreQry
                {
                    genre = genre
                });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}