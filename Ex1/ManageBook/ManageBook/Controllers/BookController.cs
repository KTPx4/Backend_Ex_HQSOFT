using BookStore.DTOs;
using BookStore.Services;
using ManageBook.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : BaseController
    {
        private readonly BookService bookService;
        private readonly AuthorService authorService;

        public BookController(BookService bookService, AuthorService authorService)
        {
            this.bookService = bookService;
            this.authorService = authorService;
        }

        // get all books
        [HttpGet("fetch")]
        public async Task<IActionResult> GetAllBook()
        {
            try
            {
                var books = await bookService.GetAllBook();
                if (books == null)
                {
                    return Ok(new { message = "No data" });
                }

                return Ok(new
                {
                    message = "Get all book success",
                    length = books.Count,
                    data = books
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("-------------Error: " + ex.Message);
                return ServerErrorResponse();
            }
        }

        // get book by id
        [HttpGet("fetch/{BookId}")]
        public async Task<IActionResult> GetBookById(int BookId)
        {
            try
            {
                var author = await bookService.GetBookById(BookId);

                // if can't find author
                if (author == null)
                {
                    return NotFound();
                }

                return Ok(new
                {
                    message = "Get book by id success",
                    data = author
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("-------------Error: " + ex.Message);
                return ServerErrorResponse();
            }
        }

        // create new book
        [HttpPost("insert")]
        public async Task<IActionResult> CreateBook(CreateBookModel bookModel)
        {
            try
            {
                var author = await authorService.GetAuthorById(bookModel.AuthorId);
                
                if (author == null)
                {
                    return BadRequest(new
                    {
                        message = "Author not exists"
                    });
                }

                var newBook = await bookService.CreateBook(bookModel);
                
                newBook.Author = author;

                return Ok(new
                {
                    message = "Create new book successful",
                    data = newBook
                });

            }
            catch (Exception ex)
            {
                Console.WriteLine("-------------Error: " + ex.Message);
                return ServerErrorResponse();
            }
        }

        // update book
        [HttpPut("update")]
        public async Task<IActionResult> UpdateBook(UpdateBookModel updateBookModel)
        {
            try
            {
                var isExistsBook = await bookService.IsExistsBookById(updateBookModel.BookId);
                Author author = await authorService.GetAuthorById(updateBookModel.AuthorId);
                if (!isExistsBook || author == null)
                {
                    return BadRequest(new
                    {
                        message = "Book or author is not exists"
                    });
                }

                var book = await bookService.UpdateBook(updateBookModel);

                return Ok(new
                {
                    message = "Update book successful",
                    data = book
                });

            }
            catch (Exception ex)
            {
                Console.WriteLine("-------------Error: " + ex.Message);
                return ServerErrorResponse();
            }
        }

        // delete book
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                Book book = await bookService.GetBookById(id);

                if (book == null)
                {
                    return BadRequest(new
                    {
                        message = "Book not exists"
                    });
                }

                var rs = await bookService.DeleteBook(book);
                return Ok(new
                {
                    message = "Delete book successful",
                    data = book
                });

            }
            catch (Exception ex)
            {
                Console.WriteLine("-------------Error: " + ex.Message);
                return ServerErrorResponse();
            }
        }
    }
}
