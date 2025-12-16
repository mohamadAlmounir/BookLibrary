using BooksLibrary.core;
using BooksLibrary.core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooksLibrary.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IBooksRepository Book { get; private set; }

        public IAuthorsRepository Author { get; private set; }

        public IGenresRepository genre { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Book = new Repositories.BooksRepository(_context);
            Author = new Repositories.AuthorsRepository(_context);
            genre = new Repositories.GenresRepository(_context);
        }
        public async Task<int> CompleteAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // خطأ بسبب التزامن (سجل اتعدل أو انمسح من شخص آخر)
                Console.WriteLine($"Concurrency error: {ex.Message}");
                throw; // ممكن ترجع خطأ مخصص بدالك
            }
            catch (DbUpdateException ex)
            {
                // خطأ في قواعد البيانات (FK, Unique...)
                Console.WriteLine($"Database error: {ex.InnerException?.Message ?? ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                // أي خطأ غير متوقع
                Console.WriteLine($"Unexpected error: {ex.Message}");
                throw;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
