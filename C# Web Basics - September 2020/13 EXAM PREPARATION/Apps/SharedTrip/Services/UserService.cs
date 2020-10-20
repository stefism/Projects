using Microsoft.EntityFrameworkCore.Internal;
using SharedTrip.Data;
using System.Linq;

namespace SharedTrip.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext db;

        public UserService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateUser(string username, string password, string email)
        {
            User user = new User
            {
                Username = username,
                Password = password,
                Email = email
            };

            db.Users.Add(user);
            db.SaveChanges();
        }

        public bool IsEmailAvailable(string email)
        {
            return !db.Users.Any(u => u.Email == email);
        }

        public bool IsUsernameAvailable(string username)
        {
            return !db.Users.Any(u => u.Username == username);
        }
    }
}
