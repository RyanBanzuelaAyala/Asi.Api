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
using Moq;
using Tamm.QApi.Controllers.Product;

namespace Asi.Api.Test
{
    public class AuthorBookControllerTest
    {
        private readonly AuthorBookController _controller;
        private readonly Mock<IMediator> _mediatorMock;

        public AuthorBookControllerTest()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new AuthorBookController(_mediatorMock.Object);
        }

        [Fact]
        public async Task CreateAuthor_ReturnsAuthor_WhenAuthorIsCreatedSuccessfully()
        {
            // Arrange
            var author = new Author { Name = "Ryan Ayala" };
            var expectedAuthor = new Author { Id = 1, Name = "Ryan Ayala" };

            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateAuthorCmd>(), default))
                .ReturnsAsync(expectedAuthor);

            // Act
            var result = await _controller.CreateAuthor(author);

            // Assert
            var actionResult = Assert.IsType<ActionResult<Author>>(result);
            var returnedAuthor = Assert.IsType<Author>(actionResult.Value);

            Assert.Equal(expectedAuthor, returnedAuthor);
        }

        [Fact]
        public async Task CreateBookWithAuthor_ReturnsBook_WhenBookIsCreatedSuccessfully()
        {
            // Arrange
            var book = new Book { Title = "Test Book", Genre = "Fiction" };

            var authorId = 1;
            var expectedBook = new Book { Id = 1, Title = "Test Book", Genre = "Fiction" };

            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateBookWithAuthorCmd>(), default))
                .ReturnsAsync(expectedBook);

            // Act
            var result = await _controller.CreateBookWithAuthor(book, authorId);

            // Assert
            var actionResult = Assert.IsType<ActionResult<Book>>(result);
            var returnedBook = Assert.IsType<Book>(actionResult.Value);

            Assert.Equal(expectedBook, returnedBook);
        }

        [Fact]
        public async Task UpdateBookDetails_ReturnsBook_WhenBookIsUpdatedSuccessfully()
        {
            // Arrange
            var book = new Book { Id = 1, Title = "Test Book", Genre = "Fiction" };

            var expectedBook = new Book { Id = 1, Title = "Test Book", Genre = "Fiction" };

            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateBookDetailsCmd>(), default))
                .ReturnsAsync(expectedBook);

            // Act
            var result = await _controller.UpdateBookDetails(book);

            // Assert
            var actionResult = Assert.IsType<ActionResult<Book>>(result);
            var returnedBook = Assert.IsType<Book>(actionResult.Value);

            Assert.Equal(expectedBook, returnedBook);
        }

        [Fact]
        public async Task RemoveBookFromAuthor_ReturnsBookWithNoAuthorId_WhenBookIsRemovedSuccessfully()
        {
            // Arrange
            var book = new Book { Title = "Test Book", Genre = "Fiction" };

            var authorId = 1;
            var expectedBook = new Book { Id = 1, Title = "Test Book", Genre = "Fiction" };

            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateBookWithAuthorCmd>(), default))
                .ReturnsAsync(expectedBook);

            // Act
            var resultAdd = await _controller.CreateBookWithAuthor(book, authorId);

            // Arrange
            int bookIdRemove = 1;
            var expectedBookRemove = new Book { Id = 1, Title = "Test Book", Genre = "Fiction", AuthorId = 0 };

            _mediatorMock.Setup(m => m.Send(It.IsAny<RemoveBookFromAuthorCmd>(), default))
                .ReturnsAsync(expectedBookRemove);

            // Act
            var resultIfRemove = await _controller.RemoveBookFromAuthor(bookIdRemove);

            // Assert
            var actionResult = Assert.IsType<ActionResult<Book>>(resultIfRemove);
            var returnedBook = Assert.IsType<Book>(actionResult.Value);

            Assert.Equal(expectedBookRemove, returnedBook);
        }

        [Fact]
        public async Task ListBookByAuthor_ReturnsListOfBooksAuthored_WhenBooksAreFound()
        {
            // Arrange
            int authorId = 1; // Assuming this author ID is valid
            var expectedBooks = new List<Book>
            {
                new Book { Id = 1, Title = "Test Book 1", Genre = "Fiction", AuthorId = authorId },
                new Book { Id = 2, Title = "Test Book 2", Genre = "Non-Fiction", AuthorId = authorId }
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<ListByAuthorQry>(), default))
                .ReturnsAsync(expectedBooks);

            // Act
            var result = await _controller.ListBookByAuthor(authorId);

            // Assert
            var actionResult = Assert.IsType<List<Book>>(result);

            Assert.Equal(expectedBooks.Count, actionResult.Count());
        }

        [Fact]
        public async Task ListBookByGenre_ReturnsListOfBooksGenre_WhenBooksAreFound()
        {
            // Arrange
            string genre = "Fiction"; // Assuming this author ID is valid
            var expectedBooks = new List<Book>
            {
                new Book { Id = 1, Title = "Test Book 1", Genre = "Fiction", AuthorId = 1 },
                new Book { Id = 2, Title = "Test Book 2", Genre = "Non-Fiction", AuthorId = 1 },
                new Book { Id = 3, Title = "Test Book 3", Genre = "Fiction", AuthorId = 1 }
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<ListByGenreQry>(), default))
                .ReturnsAsync(expectedBooks);

            // Act
            var result = await _controller.ListBookByGenre(genre);

            // Assert
            var actionResult = Assert.IsType<List<Book>>(result);

            Assert.Equal(expectedBooks.Count, actionResult.Count());
        }
    }
}