using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Business.AuthorizationServices.Abstract;
using Business.AuthorizationServices.Concrete;
using Business.CommonServices.ICommonUserInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IConfiguration configuration, IUserService userService) : ControllerBase
    {

        [HttpPost("Login")]
        public ActionResult Login(string email, string password)
        {
            var result = userService.GetUserByEmailAndPassword(email, password);

            if (result!=null)
            {
                var token = GetJwtToken(email, password);
                return Ok(token);
            }

            return Ok("fail");
        }


        private string GetJwtToken(string email, string password)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Jwt:Key"]));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub,email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),

            };

            var user = userService.GetUserByEmailAndPassword(email, password);

            var roles = userService.GetUserOperationClaims(user.Id);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
            }

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Audience"],
                audience: configuration["Jwt:Audience"],
                claims:claims,
                expires:DateTime.Now.AddMinutes(Convert.ToDouble(configuration["Jwt:Expires"])),
                signingCredentials:credentials

            );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
