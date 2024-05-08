using Business.Services.Obs.Abstract;
using Entities.ObsEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ObsWebUI.Controllers
{
    [Authorize]
    public class FacultiesController : Controller
    {
        private IFacultyService _facultyService;

        public FacultiesController(IFacultyService facultyService)
        {
            _facultyService = facultyService;
        }

        // GET: Faculties
        public async Task<IActionResult> Index()
        {
            return View(_facultyService.GetList(p=>p.Name.Contains("x")));
        }

        // GET: Faculties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faculty = _facultyService.Get(p => p.Id == id);
            if (faculty == null)
            {
                return NotFound();
            }
            return View(faculty);

        }

        // GET: Faculties/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DeanName")] Faculty faculty)
        {

            if (ModelState.IsValid)
            {
                _facultyService.Add(faculty);
                return RedirectToAction(nameof(Index));
            }

            return View(faculty);

        }

        // GET: Faculties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faculty = _facultyService.Get(p => p.Id == id);
            if (faculty == null)
            {
                return NotFound();
            }

            return View(faculty);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DeanName")] Faculty faculty)
        {
            if (id != faculty.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _facultyService.Update(faculty);
                }
                catch (Exception ex)
                {
                    if (!_facultyService.Any(p=>p.Id==faculty.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(faculty);
        }

        // GET: Faculties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faculty = _facultyService.Get(p => p.Id == id);
            if (faculty == null)
            {
                return NotFound();
            }

            return View(faculty);
        }

        // POST: Faculties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var faculty = _facultyService.Get(p => p.Id == id);
            if (faculty != null)
            {
                _facultyService.Remove(faculty);
            }

            return RedirectToAction(nameof(Index));
        }

     
    }
}
