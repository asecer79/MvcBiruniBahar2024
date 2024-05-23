﻿using System.Net;
using System.Net.Http.Headers;
using Entities.ObsEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ObsWebUI.Models;

namespace ObsWebUI.Controllers
{
    [Authorize]
    public class FacultiesController(HttpClient client) : Controller
    {
        private HttpClient _client = client;
        private string baseUrl = BaseParams.ApiBaseUrl;


        // GET: Faculties
        public async Task<IActionResult> Index()
        {
           


            var controller = "faculties";
            var action = "getList";
            var fullAddress = $"{baseUrl}/{controller}/{action}";

            var token = HttpContext.Session.GetString("token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _client.GetFromJsonAsync<IEnumerable<Faculty>>(fullAddress);

            return View(response);
        }

        // GET: Faculties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var controller = "faculties";
            var action = "get";
            var fullAddress = $"{baseUrl}/{controller}/{action}?id={id}";

            var token = HttpContext.Session.GetString("token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetFromJsonAsync<Faculty>(fullAddress);

            var faculty = response;

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
                var controller = "faculties";
                var action = "create";
                var fullAddress = $"{baseUrl}/{controller}/{action}";

                var token = HttpContext.Session.GetString("token");
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await _client.PostAsJsonAsync(fullAddress,faculty);
                if (response.StatusCode==HttpStatusCode.OK)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return Content("Unauthorized");
                }
              
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

            var controller = "faculties";
            var action = "get";
            var fullAddress = $"{baseUrl}/{controller}/{action}?id={id}";

            var response = await _client.GetFromJsonAsync<Faculty>(fullAddress);

            var faculty = response;

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

                    var controller = "faculties";
                    var action = "Edit";
                    var fullAddress = $"{baseUrl}/{controller}/{action}";

                    var response = await _client.PostAsJsonAsync(fullAddress, faculty);
                }
                catch (Exception ex)
                {
                   
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


            var controller = "faculties";
            var action = "get";
            var fullAddress = $"{baseUrl}/{controller}/{action}?id={id}";

            var response = await _client.GetFromJsonAsync<Faculty>(fullAddress);

            var faculty = response;

            return View(faculty);
        }

        // POST: Faculties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var controller1 = "faculties";
            var action1 = "get";
            var fullAddress1 = $"{baseUrl}/{controller1}/{action1}?id={id}";

            var response1 = await _client.GetFromJsonAsync<Faculty>(fullAddress1);

            var faculty1 = response1;

            var controller = "faculties";
            var action = "delete";
            var fullAddress = $"{baseUrl}/{controller}/{action}";

            var response = await _client.PostAsJsonAsync(fullAddress, faculty1);

            return RedirectToAction(nameof(Index));
        }


    }
}
