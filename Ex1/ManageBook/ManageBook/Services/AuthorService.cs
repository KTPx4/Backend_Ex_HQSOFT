using BookStore.DTOs;
using ManageBook.Data;
using ManageBook.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Services
{
    public class AuthorService
    {
        private readonly APIDBContext _dbContext;

        public AuthorService(APIDBContext dbContext)
        {
           _dbContext =  dbContext;
        }

        // get all author
        public async Task<List<Author>> GetAllAuthors()
        {
            return await _dbContext.GetAllAuthors();
        }


        // get author by id
        public async Task<Author> GetAuthorById(int id)
        {
            return await _dbContext.GetAuthorById(id);
        }


        // create author
        public async Task<Author> CreateAuthor(CreateAuthorModel authorModel)
        {
            Author newAuthor = new Author()
            {
                Name = authorModel.Name,
                Bio = authorModel.Bio ?? "",
            };
            await _dbContext.Authors.AddAsync(newAuthor);
            await _dbContext.SaveChangesAsync();
            return newAuthor;
        }

        // update author 
        public async Task<bool> UpdateAuthor(Author authorUpdate)
        {
            _dbContext.Authors.Update(authorUpdate);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        // delete author
        public async Task<bool> DeleteAuthor(Author author)
        {
            _dbContext.Authors.Remove(author);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
