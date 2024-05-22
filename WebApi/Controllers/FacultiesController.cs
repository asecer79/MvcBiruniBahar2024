using Business.Services.Obs.Abstract;
using Entities.ObsEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("ObsApi/[controller]")]
    public class FacultiesController : ControllerBase
    {
        private IFacultyService _facultyService;

        public FacultiesController(IFacultyService facultyService)
        {
            _facultyService = facultyService;
        }

        [HttpGet("Get")]
        public Task<IActionResult> Get(int id)
        {
            var result = _facultyService.Get(p => p.Id == id);
            var response = Ok(result);

            return Task.FromResult<IActionResult>(response);
        }



        [Authorize(Roles = "Admin")]
        [HttpGet("GetList")]
        public Task<IActionResult> GetList()
        {
            var result = _facultyService.GetList();

            var response = Ok(result);

            return Task.FromResult<IActionResult>(response);
        }
        [Authorize(Roles = "admin")]
        [HttpPost("Create")]
        public Task<IActionResult> Create(Faculty entity)
        {
            var result = _facultyService.Add(entity);
            var response = Ok(result);

            return Task.FromResult<IActionResult>(response);
        }

        [Authorize(Roles = "user")]
        [HttpPost("Edit")]
        public Task<IActionResult> Edit(Faculty entity)
        {
            var result = _facultyService.Update(entity);
            var response = Ok(result);

            return Task.FromResult<IActionResult>(response);
        }

        [HttpPost("Delete")]
        public Task<IActionResult> Delete(Faculty entity)
        {
            var result = _facultyService.Remove(entity);
            var response = Ok(result);

            return Task.FromResult<IActionResult>(response);
        }
    }
}
