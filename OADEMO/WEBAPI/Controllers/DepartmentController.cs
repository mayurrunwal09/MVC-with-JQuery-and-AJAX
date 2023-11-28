using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.SERVICE;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IService<Department> _department;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<DepartmentController> _logger; 
        
        public DepartmentController(IService<Department>department,IWebHostEnvironment webHostEnvironment, ILogger<DepartmentController> logger)
        {
            _department = department;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }
        [HttpGet("Get All Department")]
        public IActionResult GetAll()
        {
            var dep = _department.GetAll();
            if(dep is not null)
            {
                return Ok(dep);
            }
            return BadRequest();
        }
        [HttpGet("Get by id")]
        public IActionResult Get(int id)
        {
            var dep = _department.Get(id); 
            if(dep is not null)
            {
                return Ok(dep);
            }
            return BadRequest("Not Found");
        }
        [HttpPost("Add Department")]
        public IActionResult Insert(Department department)
        {
            if(department is not null)
            {
                _department.Insert(department);
                return Ok(department);
                   
            }
            return BadRequest("Not Found");
        }
        [HttpPut("Edit Department")]
        public IActionResult Update(Department department)
        {
            if(department != null)
            {
                _department.Update(department);
                return Ok(department);
            }
            return BadRequest("Not Found");
        }
        [HttpDelete("Delete Department")]
        public IActionResult Delete(int id)
        {
            _department.Delete(id);
            return Ok(id);
        }
    }
}
