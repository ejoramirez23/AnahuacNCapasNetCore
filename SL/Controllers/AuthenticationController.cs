using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SL.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SL.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly string secretKey;

        public AuthenticationController(IConfiguration configuration)
        {
            secretKey = configuration.GetSection("settings").GetSection("secretKey").ToString();
        }

        [HttpPost]
        [Route("Validar")]

        public IActionResult Validar([FromBody] Usuario request) 
        {
            if(request.Email == "example@gmail.com" && request.Pass == "123")
            {
                var keyBytes = Encoding.ASCII.GetBytes(secretKey);
                var claims = new ClaimsIdentity();

                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, request.Email));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

                string tokenCreado = tokenHandler.WriteToken(tokenConfig);

                return StatusCode(StatusCodes.Status200OK, new { token = tokenCreado });


            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { token = "" });
            }
        }



     
    }
}
