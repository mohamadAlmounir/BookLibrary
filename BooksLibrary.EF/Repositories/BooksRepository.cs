using BooksLibrary.core.Dtos;
using BooksLibrary.core.Models;
using BooksLibrary.core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooksLibrary.EF.Repositories
{
    public class BooksRepository : BaseRepository<Book>, IBooksRepository
    {
    
        public BooksRepository(ApplicationDbContext context):base(context) 
        {
            
        }
        public async Task<ResultDto<Book>> AddNew(BookDto newBook)
        {
           
                // 1) Validation
                if (string.IsNullOrWhiteSpace(newBook.Title))
                {
                    return new ResultDto<Book>
                    {
                        Success = false,
                        Message = "Title cannot be empty",
                    };
                }

                // 2) Check Author Exists
                if (!await _context.Authors.AnyAsync(a => a.Id == newBook.AuthorId))
                {
                    return new ResultDto<Book>
                    {
                        Success = false,
                        Message = "Author not found",
                    };
                }

                // 3) Check Genre Exists
                if (!await _context.Genres.AnyAsync(g => g.Id == newBook.GenreId))
                {
                    return new ResultDto<Book>
                    {
                        Success = false,
                        Message = "Genre not found",
                    };
                }

                // 4) Check Title Duplication
                if (await _context.Books.AnyAsync(b => b.Title == newBook.Title))
                {
                    return new ResultDto<Book>
                    {
                        Success = false,
                        Message = "Book already exists",
                    };
                }

                // 5) Create new Book
                var book = new Book
                {
                    Title = newBook.Title,
                    Description = newBook.Description,
                    AuthorId = newBook.AuthorId,
                    GenreId = newBook.GenreId
                };

                await _context.Books.AddAsync(book);

                return new ResultDto<Book>
                {
                    Success = true,
                    Message = "Book added successfully",
                    Data = book,
                };
           
        }
        public async Task<ResultDto<IEnumerable<Book>>> FindAllByAuthor(string AuthorName)
        {
            if (string.IsNullOrEmpty(AuthorName))
                return new ResultDto<IEnumerable<Book>>
                {
                    Success = false,
                    Message = "Author name cannot be empty"
                }; 
            var author=await _context.Authors.FirstOrDefaultAsync(x=>x.Name==AuthorName);
            if (author == null)
                return new ResultDto<IEnumerable<Book>>
                {
                    Success = false,
                    Message = "Author is not existed"
                };
                
            
            var booksList = await _context.Books.AsNoTracking().Include(b=>b.Genre).Include(b=>b.Author).
                Where(x => x.AuthorId == author.Id).ToListAsync();


            return new ResultDto<IEnumerable<Book>>
            {
                Success = true,
                Message = booksList.Any() ? "Books found" : "No books for this author",
                Data = booksList
            };
            
        }

        public async Task<ResultDto<IEnumerable<Book>>> FindAllByGenre(int GenreId)
        {
            var genre = await _context.Genres.FindAsync(GenreId);
            if (genre == null)
            {
                return new ResultDto<IEnumerable<Book>>
                {
                    Success = false,
                    Message="Genre is not existed"
                };
            }

            var booksList = await _context.Books.AsNoTracking().Include(b => b.Genre).Include(b => b.Author).
                Where(x => x.GenreId == GenreId).ToListAsync();


            return new ResultDto<IEnumerable<Book>>
            {
                Success = true,
                Message = booksList.Any() ? "Books found" : "No books found for this genre",
                Data = booksList
            };
        }

        public async Task<ResultDto<Book>> FindByTitle(string title)
        {
            var result = await _context.Books.AsNoTracking().Include(b=>b.Author).Include(b=>b.Genre)
                .FirstOrDefaultAsync(b => b.Title == title);

            if (result == null)
                return new ResultDto<Book>
                {
                    Success = false,
                    Message = "Book not found"
                };

            return new ResultDto<Book>
            {
                Success = true,
                Message = "Book found",
                Data = result
            };
        }

        public async Task<ResultDto<Book>> Update(int Id, BookDto UpdatedBook)
        {
            
                // 1) Find Book
                var book = await _context.Books.FindAsync(Id);

                if (book == null)
                {
                    return new ResultDto<Book>
                    {
                        Success = false,
                        Message = $"Book with Id {Id} does not exist",
                    };
                }

                // 2) Validate Title
                if (string.IsNullOrWhiteSpace(UpdatedBook.Title))
                {
                    return new ResultDto<Book>
                    {
                        Success = false,
                        Message = "Title cannot be empty",

                    };
                }

                // 3) Validate Author
                if (!await _context.Authors.AnyAsync(a => a.Id == UpdatedBook.AuthorId))
                {
                    return new ResultDto<Book>
                    {
                        Success = false,
                        Message = "Author not found",

                    };
                }

                // 4) Validate Genre
                if (!await _context.Genres.AnyAsync(g => g.Id == UpdatedBook.GenreId))
                {
                    return new ResultDto<Book>
                    {
                        Success = false,
                        Message = "Genre not found",

                    };
                }

                // 5) Update properties
                book.Title = UpdatedBook.Title;
                book.Description = UpdatedBook.Description;
                book.AuthorId = UpdatedBook.AuthorId;
                book.GenreId = UpdatedBook.GenreId;

                return new ResultDto<Book>
                {
                    Success = true,
                    Message = "Book updated successfully",
                    Data = book,

                };
            
           
            
        }

        public async Task<ResultDto<Book>> Delete(int id)
        {
            var book = await _context.Set<Book>().FindAsync(id);

            if (book == null)
            {
                return new ResultDto<Book>
                {
                    Success = false,
                    Message = $"book with ID {id} does not exist",
                };
            }


            _context.Books.Remove(book);


            return new ResultDto<Book>
            {
                Success = true,
                Message = "Item deleted successfully",
                Data = book,
            };

        }


    }
}
