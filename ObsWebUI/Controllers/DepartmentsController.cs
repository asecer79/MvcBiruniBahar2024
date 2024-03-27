using DataAccess.ObsDbContext.Ef.Dal.Abstract;
using Entities.ObsEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ObsWebUI.Controllers
{
    public class DepartmentsController : Controller
    {
        private IDepartmentDal _departmentDal;
        IFacultyDal _faultyDal;

        public DepartmentsController(IDepartmentDal departmentDal, IFacultyDal faultyDal)
        {
            _departmentDal = departmentDal;
            _faultyDal = faultyDal;
        }

        // GET: Departments
        public async Task<IActionResult> Index()
        {
            return View(_departmentDal.GetList());
        }

        // GET: Departments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = _departmentDal.Get(p => p.Id == id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);

        }

        // GET: Departments/Create
        public IActionResult Create()
        {
            ViewBag.Faculties = _faultyDal.GetList();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Department department)
        {
            ViewBag.Faculties = _faultyDal.GetList();

            if (ModelState.IsValid)
            {
                _departmentDal.Add(department);
                return RedirectToAction(nameof(Index));
            }

            return View(department);

        }

        // GET: Departments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Faculties = _faultyDal.GetList();

            if (id == null)
            {
                return NotFound();
            }

            var department = _departmentDal.Get(p => p.Id == id);
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
            ViewBag.Faculties = _faultyDal.GetList();

            if (id != department.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _departmentDal.Update(department);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_departmentDal.Any(p => p.Id == department.Id))
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

            var department = _departmentDal.Get(p => p.Id == id);
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
            var department = _departmentDal.Get(p => p.Id == id);
            if (department != null)
            {
                _departmentDal.Remove(department);
            }

            return RedirectToAction(nameof(Index));
        }

      
    }
}
