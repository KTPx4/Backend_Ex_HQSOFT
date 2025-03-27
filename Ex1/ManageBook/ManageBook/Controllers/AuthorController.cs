using BookStore.DTOs;
using BookStore.Services;
using ManageBook.Data;
using ManageBook.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorController : BaseController
    {
        private readonly AuthorService authorService;

        public AuthorController(AuthorService authorService)
        {
            this.authorService = authorService;
        }

        // get all author
        [HttpGet("fetch")]
        public async Task<IActionResult> GetAllAuthors()
        {
            try
            {
                var authors  = await authorService.GetAllAuthors();
                
                // if author has null
                if (authors == null)
                {
                    return Ok(new { message = "No data" });
                }
               
                return Ok(new
                {
                    message = "Get all author success",
                    length = authors.Count,
                    data = authors
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("-------------Error: " + ex.Message);
                return ServerErrorResponse();
            }
        }

        // get author by id
        [HttpGet("fetch/{AuthorId}")]
        public async Task<IActionResult> GetAuthorById(int AuthorId)
        {
            try
            {
                var author = await authorService.GetAuthorById(AuthorId);
                
                // if can't find author
                if (author == null)
                {
                    return NotFound();
                }

                return Ok(new
                {
                    message = "Get author by id success",
                    data = author
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("-------------Error: " + ex.Message);
                return ServerErrorResponse();
            }
        }

        // create new author
        [HttpPost("insert")]
        public async Task<IActionResult> CreateAuthor(CreateAuthorModel authorModel)
        {
            try
            {
                var newAuthor = await authorService.CreateAuthor(authorModel);

                return Ok(new
                {
                     message = "Create new author successful",
                     data = newAuthor
                });

            }
            catch(Exception ex) 
            {
                Console.WriteLine("-------------Error: " + ex.Message);
                return ServerErrorResponse();
            }
        }

        // update author
        [HttpPut("update")]
        public async Task<IActionResult> UpdateAuthor(UpdateAuthorModel updateAuthorModel)
        {
            try
            {
                Author author = await authorService.GetAuthorById(updateAuthorModel.AuthorId);
                
                if(author == null)
                {
                    return BadRequest(new
                    {
                        message = "Author not exists"
                    });
                }
                
                //update info
                author.Name = updateAuthorModel.Name;
                author.Bio = updateAuthorModel.Bio;

                await authorService.UpdateAuthor(author);

                return Ok(new
                {
                    message = "Update author successful",
                    data = author
                });

            }
            catch (Exception ex)
            {
                Console.WriteLine("-------------Error: " + ex.Message);
                return ServerErrorResponse();
            }
        }

        // delete author
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            try
            {
                Author author = await authorService.GetAuthorById(id);

                if (author == null)
                {
                    return BadRequest(new
                    {
                        message = "Author not exists"
                    });
                }

                var rs = await authorService.DeleteAuthor(author);
                return Ok(new
                {
                    message = "Delete author successful",
                    data = author
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
