﻿namespace SharedTrip.Services
{
    public interface IUserService
    {
        void CreateUser(string username, string password, string email);

        string GetUserId(string username, string password);

        bool IsUsernameAvailable(string username);

        bool IsEmailAvailable(string email);
    }
}
