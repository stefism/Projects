using Microsoft.EntityFrameworkCore.Internal;
using Musaka.Data;
using Musaka.ViewModels;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Musaka.Services
{
    class UserService : IUserService
    {
        private readonly ApplicationDbContext db;

        public UserService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateUser(CreateUserInputModel userInputModel)
        {
            User user = new User
            {
                Username = userInputModel.Username,
                Email = userInputModel.Email,
                Password = ComputeHash(userInputModel.Password)
            };

            db.Users.Add(user);
            db.SaveChanges();
        }

        public string GetUserId(string username, string password)
        {
            return db.Users.Where(u => u.Username == username && u.Password == ComputeHash(password)).Select(u => u.Id)
                .FirstOrDefault();
        }

        public bool IsEmailAvailable(string email)
        {
            return !db.Users.Any(u => u.Email == email);
        }

        public bool IsUsernameAvailable(string username)
        {
            return !db.Users.Any(u => u.Username == username);
        }

        private static string ComputeHash(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            using (var hash = SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);

                var hashedInputStringBuilder = new StringBuilder(128);
                foreach (var b in hashedInputBytes)
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                return hashedInputStringBuilder.ToString();
            }
        }
    }
}
