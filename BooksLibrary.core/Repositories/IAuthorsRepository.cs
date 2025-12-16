using BooksLibrary.core.Dtos;
using BooksLibrary.core.Interfaces;
using BooksLibrary.core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooksLibrary.core.Repositories
{
    public interface IAuthorsRepository:IBaseRepository<Author>
    {
        Task<ResultDto<Author>> FindByName(string authorName);
        Task<ResultDto<Author>> AddNew(string AuthorName);
    }
}
