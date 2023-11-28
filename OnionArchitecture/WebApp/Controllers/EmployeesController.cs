using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
      
        private readonly IService<Employee> _empService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<EmployeesController> _logger;

        public EmployeesController(IService<Employee> empservice, IWebHostEnvironment webHostEnvironment, ILogger<EmployeesController> logger)
        {
            _logger = logger;
            _empService = empservice;
            _webHostEnvironment = webHostEnvironment;
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
                if (ModelState.IsValid) 
                {
                    _empService.Insert(employee);
                    return CreatedAtAction(nameof(GetEmp), new { id = employee.EmpId }, employee); 
                }
                return BadRequest(ModelState); 
            }

            [HttpPut]
            public IActionResult UpdateUser(Employee employee)
            {
                if (ModelState.IsValid) 
                {
                    _empService.Update(employee);
                    return Ok(employee);
                }
                return BadRequest(ModelState);
            }

            [HttpDelete("{id}")]
            public IActionResult DeleteUser(int id)
            {
                _empService.Delete(id);
                return Ok(id);
            }
        }
    }

