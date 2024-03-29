﻿using DataAccess.ObsDbContext.Ef.Dal.Abstract;
using Entities.ObsEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ObsWebUI.Controllers
{
    public class FacultiesController : Controller
    {
        private IFacultyDal _facultyDal;

        public FacultiesController(IFacultyDal facultyDal)
        {
            _facultyDal = facultyDal;
        }

        // GET: Faculties
        public async Task<IActionResult> Index()
        {
            return View(_facultyDal.GetList());
        }

        // GET: Faculties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faculty = _facultyDal.Get(p => p.Id == id);
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
                _facultyDal.Add(faculty);
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

            var faculty = _facultyDal.Get(p => p.Id == id);
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
                    _facultyDal.Update(faculty);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_facultyDal.Any(p=>p.Id==faculty.Id))
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

            var faculty = _facultyDal.Get(p => p.Id == id);
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
            var faculty = _facultyDal.Get(p => p.Id == id);
            if (faculty != null)
            {
                _facultyDal.Remove(faculty);
            }

            return RedirectToAction(nameof(Index));
        }

     
    }
}
