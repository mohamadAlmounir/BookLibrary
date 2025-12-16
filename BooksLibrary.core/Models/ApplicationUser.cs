using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BooksLibrary.core.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        public string FirstName { set; get; }
        [Required]
        public string LastName { set; get; }
    }
}
