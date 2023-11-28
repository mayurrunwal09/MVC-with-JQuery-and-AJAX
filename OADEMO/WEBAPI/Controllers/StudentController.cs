using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.SERVICE;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IService<Student> _studservice;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<StudentController> _logger;

        public StudentController(IService<Student> studservice,IWebHostEnvironment webHostEnvironment,ILogger<StudentController> logger)
        {
            _studservice = studservice;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }
        [HttpGet("Get All Student")]
        public IActionResult GetAll()
        {
            var stud = _studservice.GetAll();
            if(stud != null)
            {
                return Ok(stud);
            }
            return BadRequest();
        }
        [HttpGet("Get by id")]
        public IActionResult Get(int id)
        {
            var stud = _studservice.Get(id);
            if(stud is not null)
            {
                return Ok(stud);
            }
            return BadRequest("Not Found");
        }
        [HttpPost("Add Student")]
        public IActionResult Insert(Student student)
        {       
                _studservice.Insert(student);
                return Ok(student);
       
        }
        [HttpPut("Edit Student")]
        public IActionResult Update(Student student)
        {
                _studservice.Update(student);
                return Ok(student);
           
        }

        [HttpDelete("Delete Student")]
        public IActionResult Delete(int id)
        {
            _studservice.Delete(id);
            return Ok(id);
        }

    }
}
