using BooksLibrary.core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BooksLibrary.core.Dtos
{
    public class BookDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "AuthorId is required")]
        public int AuthorId { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "GenreId is required")]
        public int GenreId { get; set; }
       
    
    }
}
