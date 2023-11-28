using Domain.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Service;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IService<Employee> _empService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IService<Employee> empservice, IWebHostEnvironment webHostEnvironment, ILogger<EmployeeController> logger)
        {
            _logger = logger;
            _empService = empservice;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet("Get All")]
        public IActionResult GetAll()
        {
            var emp = _empService.GetAll();
            if(emp is not null)
            {
                return Ok(emp);
            }
            return BadRequest("Not Found");
        }

        [HttpGet("{id}")]
        public IActionResult GetEmp(int id)
        {
            var result = _empService.Get(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult InsertUser(Employee employee)
        {
            _empService.Insert(employee);
            return Ok(employee);    
        }

        [HttpPut]
        public IActionResult UpdateUser(Employee employee)
        {
            
                _empService.Update(employee);
                return Ok(employee);
            
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            _empService.Delete(id);
            return Ok(id);
        }
    }
}
