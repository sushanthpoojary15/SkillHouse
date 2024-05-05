using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EduSync.Common.Model;
using System.Security.Claims;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.Identity.Client;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using EduSync.Business;

namespace EduSync.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            if (!ValidateUser(loginModel.Username, loginModel.Password))
            {
                return BadRequest();
            }
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub,loginModel.Username),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,DateTime.Now.ToString())
            };
            claims.Add(new Claim("Role", "Admin"));
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("!@#$%^&*()!@#$%^&*()");
            var tokenDescrptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescrptor);
            return Ok(
                new
                {
                    Token = tokenHandler.WriteToken(token)
                });
        }
        
        private LoginBusiness loginBusiness;

        public LoginController(LoginBusiness loginBusiness)
        {
            this.loginBusiness = loginBusiness;
        }
        [NonAction]

        public bool ValidateUser(string userName, string password)
        {
            return this.loginBusiness.ValidateUser(userName, password);
        }
    }
    }


        
  
