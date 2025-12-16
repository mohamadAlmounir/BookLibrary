using BooksLibrary.core.Dtos;
using BooksLibrary.core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooksLibrary.core
{
    public interface IUnitOfWork:IDisposable
    {
        IBooksRepository Book {get; }
        IAuthorsRepository Author { get; }
        IGenresRepository genre { get; }

        Task<int>CompleteAsync();
    }
}
