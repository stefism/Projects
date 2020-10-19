using Suls.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Suls.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext db;

        public UserService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateUser(string username, string email, string password)
        {
            var user = new User
            {
                Email = email,
                Username = username,
                Password = ComputeHash(password)
            };

            db.Users.Add(user);
            db.SaveChanges();
        }

        public string GetUserId(string username, string password)
        {
            var passwordHash = ComputeHash(password);
            var user = db.Users.FirstOrDefault(u => u.Username == username && u.Password == passwordHash);

            return user?.Id; // If user is null - return null, else - get user id. 
            // If "?" is missing we get Null refference exceprion when user is null.
        }

        public bool IsEmailAvailable(string email)
        {
            return !db.Users.Any(u => u.Email == email);
            // If in NOT this email in db, return true! If "!" is not exist, return true if this email exist in db.
            //Искаме да върне true ако няма такъв мейл, затова обръщаме условието с "!".
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
