using BattleCards.Data;
using Microsoft.EntityFrameworkCore.Internal;
using SUS.MvcFramework;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BattleCards.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext db; //readonly -> set only in constructor.

        public UserService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public string CreateUser(string username, string email, string password)
        {
            User user = new User
            {
                Username = username,
                Email = email,
                Role = IdentityRole.User,
                Password = ComputeHash(password)
            };

            db.Users.Add(user);
            db.SaveChanges();

            return user.Id;
        }

        public bool IsEmailAvailable(string email)
        {
            return !db.Users.Any(x => x.Email == email); //If this email is not exist in db, return true. Else, return false; Върни ми true ако този мейл го няма в базата данни.
        }

        public bool IsUsernameAvailable(string username)
        {
            return !db.Users.Any(x => x.Username == username);
        }

        public string GetUserId(string username, string password)
        {
            User user = db.Users.FirstOrDefault(u => u.Username == username);

            if (user?.Password != ComputeHash(password))
            {
                return null;
            }

            return user.Id;
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
