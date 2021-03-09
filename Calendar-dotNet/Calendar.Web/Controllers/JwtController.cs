using Calendar.App.Data;
using Calendar.App.ViewModels;
using Calendar.Web.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JwtController : ControllerBase
    {
        private readonly IOptions<JwtSettings> jwtSettings;
        private readonly ApplicationDbContext db;

        public JwtController(IOptions<JwtSettings> jwtSettings, ApplicationDbContext db)
        {
            this.jwtSettings = jwtSettings;
            this.db = db;
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult<string>> Login(LoginInputModel input)
        {
            var user = await db.Users.SingleOrDefaultAsync(x => x.UserName == input.Username);

            if (user == null) return null; // Return null if user not found

            // Authentication successful so generate jwt token

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.jwtSettings.Value.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                   {
                      new Claim(ClaimTypes.Name, input.Username.ToString()), //user.Username.ToString()
                      new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                   }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenAsString = tokenHandler.WriteToken(token); 

            return tokenAsString; 
        }

        //[Authorize]
        [HttpGet]
        public ActionResult<string> WhoAmI()
        {
            var username = User.Identity.Name;
            var user = db.Users.SingleOrDefault(x => x.UserName == username);
            var userId = user.Id;  

            return new JsonResult(new UserInfoWiewModel 
            {
                Username = username,
                UserId = userId
            });
            
        }
    }
}
