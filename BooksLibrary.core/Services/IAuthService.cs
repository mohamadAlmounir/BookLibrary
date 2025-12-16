using BooksLibrary.core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooksLibrary.core.Services
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(RegisterModel model);
        Task<AuthModel> LoginAsync(LoginModel model);
        Task<string> AddRoleAsync(AddRoleModel model);
    }
}
