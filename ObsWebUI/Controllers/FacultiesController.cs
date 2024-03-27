using DataAccess.ObsDbContext.Ef.Repository;
using Entities.ObsEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ObsWebUI.Controllers
{
    public class FacultiesController : Controller
    {

        // GET: Faculties
        public async Task<IActionResult> Index()
        {
            using (var _context = new BiruniSchoolDbContext())
            {
                return View(await _context.Faculties.ToListAsync());
            }

        }

        // GET: Faculties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using (var _context = new BiruniSchoolDbContext())
            {
                var faculty = await _context.Faculties
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (faculty == null)
                {
                    return NotFound();
                }

                return View(faculty);
            }
        }

        // GET: Faculties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Faculties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DeanName")] Faculty faculty)
        {
            using (var _context = new BiruniSchoolDbContext())
            {
                if (ModelState.IsValid)
                {
                    _context.Add(faculty);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                return View(faculty);
            }
        }

        // GET: Faculties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using (var _context = new BiruniSchoolDbContext())
            {
                var faculty = await _context.Faculties.FindAsync(id);
                if (faculty == null)
                {
                    return NotFound();
                }

                return View(faculty);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DeanName")] Faculty faculty)
        {
            if (id != faculty.Id)
            {
                return NotFound();
            }

            using (var _context = new BiruniSchoolDbContext())
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(faculty);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!FacultyExists(faculty.Id))
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
        }

        // GET: Faculties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using (var _context = new BiruniSchoolDbContext())
            {

                var faculty = await _context.Faculties
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (faculty == null)
                {
                    return NotFound();
                }

                return View(faculty);
            }
        }

        // POST: Faculties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var _context = new BiruniSchoolDbContext())
            {
                var faculty = await _context.Faculties.FindAsync(id);
                if (faculty != null)
                {
                    _context.Faculties.Remove(faculty);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }

        private bool FacultyExists(int id)
        {
            using (var _context = new BiruniSchoolDbContext())
            {
                return _context.Faculties.Any(e => e.Id == id);
            }
        }
    }
}
