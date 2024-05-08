using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Business.AuthorizationServices.Abstract;
using Business.CommonServices.ICommonUserInterfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace Business.AuthorizationServices.Concrete
{
    public class AuthService : IAuthService
    {
        private IUserService _userService;
        private IHttpContextAccessor _httpContextAccessor;

        public AuthService(IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
        }

        public async Task<bool> SignInAsync(string email, string password)
        {
            var user = _userService.GetUserByEmailAndPassword(email, password);

            if (user == null)
            {
                return await Task.FromResult(false);
            }

            else
            {
                var userOperationClaims = _userService.GetUserOperationClaims(user.Id);

                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Email,user.Email),
                    new Claim(ClaimTypes.Name,$"{user.FName} {user.LName}"),
                    new Claim(ClaimTypes.NameIdentifier,$"{user.Email}"),
                };

                foreach (var userOperationClaim in userOperationClaims)
                {
                    claims.Add(new Claim(ClaimTypes.Role, userOperationClaim.Name));
                }

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return true;
            }
        }

        public async Task SignOutAsync()
        {
            await _httpContextAccessor.HttpContext.SignOutAsync();
        }
    }
}
