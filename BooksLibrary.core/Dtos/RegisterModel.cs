using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BooksLibrary.core.Dtos
{
    public class RegisterModel
    {
        [Required, MaxLength(75)]
        public string FirstName { get; set; }
        [Required, MaxLength(75)]
        public string LastName { get; set; }
        [Required, MaxLength(75)]
        public string UserName { get; set; }
        [Required, MaxLength(75)]
        [EmailAddress]
        public string Email { get; set; }
        [Required, MaxLength(75)]
        public string Password { get; set; }
    }
}
