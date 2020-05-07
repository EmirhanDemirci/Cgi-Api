using System;
using System.Collections.Generic;
using System.Text;
using Cgi_Api.Models;

namespace Cgi_Api.Services.Interfaces
{
    public interface IUserService
    {
        void Create(User user);
        JwtUser Authenticate(string username, string password);
        User Get(int id);
    }
}
