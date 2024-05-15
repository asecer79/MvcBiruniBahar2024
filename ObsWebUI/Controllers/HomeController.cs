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
            //using (var db = new BiruniSchoolDbContext())
            //{
            //    var faculties = db.Faculties.ToList();

            //}

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
