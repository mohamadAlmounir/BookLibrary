using BooksLibrary.core.Dtos;
using BooksLibrary.core.Interfaces;
using BooksLibrary.core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooksLibrary.core.Repositories
{
    public interface IBooksRepository:IBaseRepository<Book>
    {
        Task<ResultDto<Book>> FindByTitle(string title);

        Task<ResultDto<IEnumerable<Book>>> FindAllByAuthor(string AuthorName);

        Task<ResultDto<IEnumerable<Book>>> FindAllByGenre(int GenreId);

        Task<ResultDto<Book>> AddNew(BookDto NewBook); 

        Task<ResultDto<Book>> Update(int Id,BookDto UpdatedBook);
        Task<ResultDto<Book>> Delete(int id);
    }
}
