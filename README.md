# ASI API Project

This project is a Web API that provides functionalities to manage authors and books. It allows you to create, update, retrieve, and delete books and authors.

## Features

- Create authors.
- Create and manage books associated with authors.
- List books by author and genre.
- Remove books from authors.

## Technologies Used

- ASP.NET Core
- Entity Framework Core
- MediatR
- xUnit (for unit testing)
- Moq (for mocking dependencies)

## Getting Started

### Prerequisites

Make sure you have the following software installed on your machine:

- [.NET 6.0 SDK or later](https://dotnet.microsoft.com/download)
- [Postman](https://www.postman.com/downloads/)

### Running the Project

Design Choices
Architecture: Describe the architecture of the application (e.g., MVC, Clean Architecture).
Patterns Used: Explain the use of design patterns like CQRS (Command Query Responsibility Segregation) with MediatR for handling commands and queries.


1. Extract Asi.Api
2. Open Asi.Api.sln
3. Run -- IIS Express
	-- https://localhost:44387/swagger/index.html

4. Open PostMan 

API Endpoints

Author Endpoints
Create Author
Method: POST
Route: /CreateAuthor
CURL : curl -X 'POST' \
  'https://localhost:44387/AuthorBook/CreateAuthor' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '{
  "id": 1,
  "name": "string"
}'

Create Book with Author
Method: PUT
Route: /CreateBookWithAuthor
CURL : curl -X 'PUT' \
  'https://localhost:44387/AuthorBook/CreateBookWithAuthor?authorId=1' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '{
  "id": 1,
  "title": "Test Book 1",
  "genre": "Fiction",
  "authorId": 1
}'

List Books by Author
Method: POST
Route: /ListBookByAuthor
CURL : curl -X 'POST' \
  'https://localhost:44387/AuthorBook/ListBookByAuthor' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '1'


Update Book Details
Method: PUT
Route: /UpdateBookDetails
CURL : curl -X 'PUT' \
  'https://localhost:44387/AuthorBook/UpdateBookDetails' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '{
  "id": 1,
  "title": "Test Book 1 - New",
  "genre": "Fiction",
  "authorId": 1
}'


Remove Book from Author
Method: DELETE
Route: /RemoveBookFromAuthor
CURL : curl -X 'DELETE' \
  'https://localhost:44387/AuthorBook/RemoveBookFromAuthor' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '1'

### Testing the Project

1. Extract Asi.Api
2. Open Asi.Api.sln
3. Goto View -> Test Explorer
	- Run All
	- Debug All 

License
This project is licensed under the MIT License. See the LICENSE file for more details.
