using Musaka.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Musaka.Services
{
    public interface IUserService
    {
        void CreateUser(CreateUserInputModel userInputModel);

        string GetUserId(string username, string password);

        bool IsUsernameAvailable(string username);

        bool IsEmailAvailable(string email);
    }
}
