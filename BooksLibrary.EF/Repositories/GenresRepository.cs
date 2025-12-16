using BooksLibrary.core.Dtos;
using BooksLibrary.core.Models;
using BooksLibrary.core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooksLibrary.EF.Repositories
{
    public class GenresRepository:BaseRepository<Genre>,IGenresRepository
    {
        public GenresRepository(ApplicationDbContext context):base(context)
        {
            
        }

        public async Task<ResultDto<Genre>> AddNew(string GenreName)
        {
            // 1) Validation
            if (string.IsNullOrWhiteSpace(GenreName))
            {
                return new ResultDto<Genre>
                {
                    Success = false,
                    Message = "Name cannot be empty",
                };
            }

            // 2) Check Genre Doblication
            if (await _context.Genres.AnyAsync(a => a.Name == GenreName))
            {
                return new ResultDto<Genre>
                {
                    Success = false,
                    Message = "Genre Already Existed",
                };
            }



            // 5) Create new Book
            var genre = new Genre
            {
                Name = GenreName
            };


            await _context.Genres.AddAsync(genre);

            return new ResultDto<Genre>
            {
                Success = true,
                Message = "Author added successfully",
                Data = genre,
            };

        }
    }
}
