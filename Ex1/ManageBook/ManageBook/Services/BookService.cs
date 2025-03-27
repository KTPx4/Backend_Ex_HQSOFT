using BookStore.DTOs;
using ManageBook.Data;
using ManageBook.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Services
{
    public class BookService
    {
        private readonly APIDBContext _dbContext;

        public BookService(APIDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        // get all book
        public async Task<List<Book>> GetAllBook()
        {
            return await _dbContext.GetAllBooks();
        }


        public async Task<bool> IsExistsBookById(int id)
        {
            var book = await _dbContext.Books.Where(b => b.BookId == id).FirstOrDefaultAsync();
            return book != null;
        }

        // get author by id
        public async Task<Book> GetBookById(int id)
        {
            return await _dbContext.GetBookById(id);
        }

        // create book
        public async Task<Book> CreateBook(CreateBookModel createBookModel)
        {
            Book newBook = new Book()
            {
                AuthorId = createBookModel.AuthorId,
                Price = createBookModel.Price,
                Title = createBookModel.Title,
                PublishedDate = createBookModel.PublishedDate,
            };
            await _dbContext.Books.AddAsync(newBook);
            await _dbContext.SaveChangesAsync();
            return newBook;
        }

        //update book

        public async Task<Book> UpdateBook(UpdateBookModel updateBookModel)
        {
            var book = await _dbContext.Books.Where(b => b.BookId == updateBookModel.BookId).FirstOrDefaultAsync();
            // update info
            book.Title = updateBookModel.Title;
            book.AuthorId = updateBookModel.AuthorId;
            book.PublishedDate = updateBookModel.PublishedDate;
            book.Price = updateBookModel.Price;

            await _dbContext.SaveChangesAsync();
            return book;
        }

        //delete book
        public async Task<bool> DeleteBook(Book book)
        {
            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
