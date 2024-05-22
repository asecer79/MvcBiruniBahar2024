using System.Text;
using Business.AuthorizationServices.Abstract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ObsWebUI.Controllers
{
    public class AuthController(IAuthService authService, HttpClient httpClient) : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var isAuth =await authService.SignInAsync(email, password);

            if (isAuth)
            {
                var url = "https://localhost:7175/api/Auth/Login";

                var userInfo = new { email = email, password = password };

                var json = JsonConvert.SerializeObject(userInfo);

                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(url,data);

                var token = await response.Content.ReadAsStringAsync();

                
                HttpContext.Session.SetString("token",token);

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
             await authService.SignOutAsync();

            return RedirectToAction("Login");

        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

   

    }
}
