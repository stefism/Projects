using Calendar.App.Data;
using Calendar.Web.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Calendar.Web.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext context;
        private readonly JwtSettings jwtSettings;

        public UserService(ApplicationDbContext context, IOptions<JwtSettings> jwtSettings)
        {
            this.context = context;
            this.jwtSettings = jwtSettings.Value;
        }

        public IdentityUser Authenticate(string username, string password)
        {
            IdentityUser user = context.Users
                .SingleOrDefault(x => x.UserName == username && x.PasswordHash == password);
            if (user == null) return null; // Return null if user not found

            // Authentication successful so generate jwt token

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                   {
                      new Claim(ClaimTypes.Name, user.UserName.ToString()),
                      new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                   }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenAsString = tokenHandler.WriteToken(token);

            return user;
        }
    }
}
