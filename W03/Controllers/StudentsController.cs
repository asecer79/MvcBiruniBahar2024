using Microsoft.AspNetCore.Mvc;
using W03.Models;

namespace W03.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            var students = SchoolDb.Students.OrderBy(p=>p.Id).ToList();
            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var student = new Student();
            return View(student);
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            var maxId= SchoolDb.Students.Max(p=>p.Id);
            if (ModelState.IsValid)
            {
                student.Id = maxId+1;
                SchoolDb.Students.Add(student);

               return RedirectToAction("Index");
            }

            return View(student);
        }

        [HttpGet]
        public IActionResult Edit(int studentId)
        {
            var student = SchoolDb.Students.FirstOrDefault(p => p.Id == studentId);
            return View(student);

        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            var studentOld = SchoolDb.Students.FirstOrDefault(p => p.Id == student.Id);
            SchoolDb.Students.Remove(studentOld);

            if (ModelState.IsValid)
            {
                SchoolDb.Students.Add(student);

                return RedirectToAction("Index");
            }

            return View(student);

        }

        [HttpGet]
        public IActionResult Delete(int studentId)
        {
            var student = SchoolDb.Students.FirstOrDefault(p => p.Id == studentId);
            SchoolDb.Students.Remove(student);
            return RedirectToAction("Index");
        }
    }
}
