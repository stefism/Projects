using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyFirstAspNetCoreApplication.Settings;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstAspNetCoreApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestJwtController : ControllerBase
    {
        private readonly IOptions<JwtSettings> jwtSettings;

        public TestJwtController(IOptions<JwtSettings> jwtSettings)
        {
            this.jwtSettings = jwtSettings;
        }

        [HttpPost]
        public IActionResult Login(JwtLoginInputModel input)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtSettings.Value.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Name, "Stefan"),
                    new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
                })
            };
        }
    }

    public class JwtLoginInputModel
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
