using BooksLibrary.core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooksLibrary.core.Interfaces
{
    public interface IBaseRepository<T> where T :class
    {
        Task<ResultDto<T>> Find(int id);

        Task<ResultDto<IEnumerable<T>>> GetAll();

        
    }
}
