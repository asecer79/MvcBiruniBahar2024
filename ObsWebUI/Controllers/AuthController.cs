using Business.AuthorizationServices.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace ObsWebUI.Controllers
{
    public class AuthController : Controller
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var isAuth =await _authService.SignInAsync(email, password);

            if (isAuth)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
             await _authService.SignOutAsync();

            return RedirectToAction("Login");

        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

   

    }
}
