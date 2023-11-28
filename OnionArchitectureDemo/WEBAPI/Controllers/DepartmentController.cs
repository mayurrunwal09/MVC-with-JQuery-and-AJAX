using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Service;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        private readonly IService<Department> _depService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<DepartmentController> _logger;

        public DepartmentController(IService<Department> depservice, IWebHostEnvironment webHostEnvironment, ILogger<DepartmentController> logger)
        {
            _logger = logger;
            _depService = depservice;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet("Get All Departments")]
        public IActionResult GetAll() 
        {
            var dep = _depService.GetAll();
            if(dep != null)
            {
                return Ok(dep);
            }
            return BadRequest("Not Found");
        }
        [HttpGet("{id}")]
        public IActionResult GetDep(int id)
        {
            var result = _depService.Get(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult InsertUser(Department department)
        {          
                _depService.Insert(department);                          
                 return Ok(department);
        }

        [HttpPut]
        public IActionResult UpdateUser(Department department)
        {          
                _depService.Update(department);
                return Ok(department);   
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            _depService.Delete(id);
            return Ok(id);
        }
    }
}
