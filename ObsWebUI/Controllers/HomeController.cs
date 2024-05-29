using Microsoft.AspNetCore.Mvc;
using ObsWebUI.Models;
using System.Diagnostics;
using DataAccess.ObsDbContext.Ef.Repository;

namespace ObsWebUI.Controllers
{
    public class HomeController : Controller
    {

   
        public IActionResult Index()
        {

            return View();
        }

    }
}
