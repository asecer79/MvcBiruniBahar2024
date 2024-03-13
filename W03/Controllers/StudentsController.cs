using Microsoft.AspNetCore.Mvc;
using W03.Models;

namespace W03.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            var students = SchoolDb.Students;
            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int studentId)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int studentId)
        {
            return View();
        }
    }
}
