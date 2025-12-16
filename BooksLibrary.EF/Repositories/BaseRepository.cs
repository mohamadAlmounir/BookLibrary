using BooksLibrary.core.Dtos;
using BooksLibrary.core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.EF.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResultDto<T>> Find(int id)
        {
            var item = await _context.Set<T>().FindAsync(id);

            if (item == null)
            {
                return new ResultDto<T>
                {
                    Success = false,
                    Message = $"Item with ID {id} was not found"
                };
            }

            return new ResultDto<T>
            {
                Success = true,
                Message = "Item was found",
                Data = item
            };
        }

        public async Task<ResultDto<IEnumerable<T>>> GetAll()
        {
            var list = await _context.Set<T>().ToListAsync();

            return new ResultDto<IEnumerable<T>>
            {
                Success = true,
                Message = list.Any() ? "Items retrieved successfully" : "No items found",
                Data = list
            };
        }



    }
}
