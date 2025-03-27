using ManageBook.Data;
using ManageBook.Models;

namespace BookStore.Services
{
    public class ReportService
    {
        private readonly APIDBContext _dbContext;
        
        public ReportService(APIDBContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<List<Book>> SearchBooks(string searchKey, int? authorId, DateTime? fromPublishedDate, DateTime? toPublishedDate, int pageSize, int pageIndex)
        {
            var books =await _dbContext.SearchBooks(searchKey, authorId, fromPublishedDate, toPublishedDate, pageSize, pageIndex);
            return books;
        }
    }
}
