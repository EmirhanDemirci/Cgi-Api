using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Linq;
using Cgi_Api.DataAccess.Data;
using Cgi_Api.Models;
using Cgi_Api.Services.Helpers;
using Cgi_Api.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;


namespace Cgi_Api.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;
        public UserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(User user)
        {
            var dbUser = _dbContext.Users.FirstOrDefault(x => x.UserName == user.UserName);

            if (dbUser == null)
            {
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new UserAlreadyExistsException("User already exists");
            }

        }

        public JwtUser Authenticate(string username, string password)
        {
            //TODO: Change hardcoded JWTKey
            var jwtKey = "1234567890123456";
            var user = _dbContext.Users.FirstOrDefault(u => u.UserName == username);

            if (user == null)
            {
                return null;
            }

            if (password != user.Password)
            {
                return null;
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Id", user.Id.ToString()),
                    //Is Admin claim
                    new Claim("Planner", user.IsPlanner.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
                    SecurityAlgorithms.HmacSha256)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);

            var jwtUser = new JwtUser();
            jwtUser.Token = token;
            jwtUser.User = user;
            return jwtUser;
        }

        public User Get(int id)
        {
            if (id != 0)
            {
                var user = _dbContext.Users.Find(id);
                return user;
            }
            return null;
        }
    }
}
