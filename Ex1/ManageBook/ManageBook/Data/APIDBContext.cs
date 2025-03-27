using BookStore.DTOs;
using ManageBook.Models;
using Microsoft.EntityFrameworkCore;
namespace ManageBook.Data
{
    public class APIDBContext : DbContext
    {
        public APIDBContext(DbContextOptions<APIDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        // book
        public async Task<List<Book>> GetAllBooks()
        {
            return await Books.FromSqlRaw("EXEC GetAllBooks").ToListAsync();
        }

        public async Task<Book> GetBookById(int bookId)
        {
            var bookDto = (await Database.SqlQueryRaw<BookDto>("EXEC GetBookById @p0", bookId)
                     .ToListAsync()) // Get list
                     .AsEnumerable() // Transform to client
                     .FirstOrDefault();

            if (bookDto == null) return null;

            var book = new Book
            {
                BookId = bookDto.BookId,
                Title = bookDto.Title,
                Price = bookDto.Price,
                AuthorId = bookDto.AuthorId,
                PublishedDate = bookDto.PublishedDate
            };

            // get info author
            book.Author = await Authors.Where(a => a.AuthorId == bookDto.AuthorId).FirstOrDefaultAsync();

            return book;
        }

        // author
        public async Task<List<Author>> GetAllAuthors()
        {
            return await Authors.FromSqlRaw("EXEC GetAllAuthors").ToListAsync();
        }

        public async Task<Author> GetAuthorById(int authorId)
        {
            var authorDto = (await Database.SqlQueryRaw<AuthorDto>("EXEC GetAuthorById @p0", authorId)
                              .ToListAsync()) // Get list
                              .AsEnumerable() // tranform to client
                              .FirstOrDefault();

            if (authorDto == null) return null;

            var author = new Author
            {
                AuthorId = authorDto.AuthorId,
                Name = authorDto.Name,
                Bio = authorDto.Bio,
            };

            // get info book
            author.Books = await Books.Where(b => b.AuthorId == author.AuthorId).ToListAsync();

            return author;
        }

        // report
        public async Task<List<Book>> SearchBooks(string searchKey, int? authorId, DateTime? fromPublishedDate, DateTime? toPublishedDate, int pageSize, int pageIndex)
        {
            return await Books.FromSqlRaw(
                "EXEC SearchBooks @p0, @p1, @p2, @p3, @p4, @p5",
                searchKey ?? (object)DBNull.Value,
                authorId ?? (object)DBNull.Value,
                fromPublishedDate ?? (object)DBNull.Value,
                toPublishedDate ?? (object)DBNull.Value,
                pageSize,
                pageIndex
            ).ToListAsync();
        }
    }
}
