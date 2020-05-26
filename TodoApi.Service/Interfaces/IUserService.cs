using System;
using System.Collections.Generic;
using System.Text;
using TodoApi.Domain;

namespace TodoApi.Service.Interfaces
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
    }
}
