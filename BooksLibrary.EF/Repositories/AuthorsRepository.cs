using BooksLibrary.core.Dtos;
using BooksLibrary.core.Models;
using BooksLibrary.core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooksLibrary.EF.Repositories
{
    public class AuthorsRepository : BaseRepository<Author>, IAuthorsRepository
    {
        public AuthorsRepository(ApplicationDbContext context):base(context)
        {
            
        }

        public async Task<ResultDto<Author>> FindByName(string authorName)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(a => a.Name == authorName);
            if (author == null)
            {
                return new ResultDto<Author>
                {
                    Success = false,
                    Message = "Author Not Found",
                    
                };
            }
            return new ResultDto<Author>
            {
                Success = true,
                Message = "Author found successfully",
                Data = author,
                
            };
        }

        public async Task<ResultDto<Author>> AddNew(string AuthorName)
        {
            // 1) Validation
            if (string.IsNullOrWhiteSpace(AuthorName))
            {
                return new ResultDto<Author>
                {
                    Success = false,
                    Message = "Name cannot be empty",
                };
            }

            // 2) Check Author Doblication
            if (await _context.Authors.AnyAsync(a => a.Name == AuthorName))
            {
                return new ResultDto<Author>
                {
                    Success = false,
                    Message = "Author Already Existed",
                };
            }

      

            // 5) Create new Book
            var author = new Author
            {
                Name = AuthorName
            };
            

            await _context.Authors.AddAsync(author);

            return new ResultDto<Author>
            {
                Success = true,
                Message = "Author added successfully",
                Data = author,
            };

        }
    }
}
