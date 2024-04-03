using Business.Obs.Abstract;
using Entities.ObsEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ObsWebUI.Controllers
{
    public class DepartmentsController : Controller
    {
        private IDepartmentService _departmentService;
        private IFacultyService _faultyService;

        public DepartmentsController(IDepartmentService departmentService, IFacultyService faultyService)
        {
            _departmentService = departmentService;
            _faultyService = faultyService;
        }

        // GET: Departments
        public async Task<IActionResult> Index()
        {
            return View(_departmentService.GetList());
        }

        // GET: Departments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = _departmentService.Get(p => p.Id == id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);

        }

        // GET: Departments/Create
        public IActionResult Create()
        {
            ViewBag.Faculties = _faultyService.GetList();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Department department)
        {
            ViewBag.Faculties = _faultyService.GetList();

            if (ModelState.IsValid)
            {
                _departmentService.Add(department);
                return RedirectToAction(nameof(Index));
            }

            return View(department);

        }

        // GET: Departments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Faculties = _faultyService.GetList();

            if (id == null)
            {
                return NotFound();
            }

            var department = _departmentService.Get(p => p.Id == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Department department)
        {
            ViewBag.Faculties = _faultyService.GetList();

            if (id != department.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _departmentService.Update(department);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_departmentService.Any(p => p.Id == department.Id))
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

            return View(department);
        }

        // GET: Departments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = _departmentService.Get(p => p.Id == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var department = _departmentService.Get(p => p.Id == id);
            if (department != null)
            {
                _departmentService.Remove(department);
            }

            return RedirectToAction(nameof(Index));
        }

      
    }
}
