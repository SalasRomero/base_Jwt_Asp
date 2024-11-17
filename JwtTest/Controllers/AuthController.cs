using JwtTest.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtTest.Controllers
{
    [Route("api/auth")]
    [ApiController] //Verifica el model state
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AuthController( IConfiguration configuration)
        {
                this._configuration = configuration;
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] UserDTO user) 
        {

            if (user.UserName == "admin" && user.Password == "password") {
                var token = this.GenerarTokenJwtToken(user.UserName);
                return Ok(new { token });
            }
            return Unauthorized();
        
        }

        //Solo por esta ocación voy a poner logica aqui
        private string GenerarTokenJwtToken(string username) {

            //Vamos a crear los calims, esto es donde va la informamción del  usuario
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub,username),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._configuration["jwt_key"]));
            var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                    issuer:null,
                    audience:null,
                    claims:claims,
                    expires:DateTime.Now.AddMinutes(3),
                    signingCredentials:creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
