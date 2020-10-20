using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Services
{
    public interface IUserService
    {
        void CreateUser(string username, string password, string email);

        bool IsUsernameAvailable(string username);

        bool IsEmailAvailable(string email);
    }
}
