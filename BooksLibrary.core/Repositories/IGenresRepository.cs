using BooksLibrary.core.Dtos;
using BooksLibrary.core.Interfaces;
using BooksLibrary.core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooksLibrary.core.Repositories
{
    public interface IGenresRepository:IBaseRepository<Genre>
    {

        Task<ResultDto<Genre>> AddNew(string GenreName);
    }
}
