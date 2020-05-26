using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using TodoApi.Domain;
using TodoApi.Service.Helpers;
using TodoApi.Service.Interfaces;

namespace TodoApi.Service
{
    public class UserService : IUserService
    {
        private List<User> _users = new List<User>
        {
            new User {
                Id = 1, FirstName = "Daniel", LastName = "Brito", Username = "daniel", Password = "test", Role= "manager"
            },
            new User {
                Id = 2, FirstName = "Jessica", LastName = "Vasconcellos", Username = "jessica", Password = "test", Role= "analyst"
            }
        };


        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public User Authenticate(string username, string password)
        {
            var user = _users.SingleOrDefault(x => x.Username.ToLower() == username.ToLower()
                                                && x.Password == password);

            if (user == null) return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            user.Password = "";

            return user;
        }

        public IEnumerable<User> GetAll() => _users.Select(x => { x.Password = null; return x; });

    }
}
