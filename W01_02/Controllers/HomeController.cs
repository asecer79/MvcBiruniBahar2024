using Microsoft.AspNetCore.Mvc;
using W01_02.Models;

namespace W01_02.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //db ye bağlan
            var student1 = new Student
            {
                Id = 1,
                FirstName = "Asya",
                LastName = "Çilek",
                Department = "Com. eng."
            };
            var student2 = new Student
            {
                Id = 2,
                FirstName = "Ahmet",
                LastName = "Karaca",
                Department = "Com. eng."
            };
            var student3 = new Student
            {
                Id = 3,
                FirstName = "Mustafa",
                LastName = "Kalay",
                Department = "Elc. eng."
            };
            List<Student> students = new List<Student>();
            students.Add(student1);
            students.Add(student2);
            students.Add(student3);

            return View(students);
        }
    }
}
