using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository_And_Services.Services.Custom.DepartmentServices;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _service;
        private readonly ILogger<DepartmentController> _logger;
        public DepartmentController(IDepartmentService service, ILogger<DepartmentController> logger)
        {
            _service = service;
            _logger = logger;
        }
        [HttpGet]   
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Getting all the data");
            var result = await _service.GetAll();
            if(result == null)
            {
                _logger.LogWarning("Data not found");
                return BadRequest("Department data not found");
            }
            return Ok(result);
        }

       

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepById(int id)
        {
            _logger.LogInformation($"Getting department by ID: {id}");
            var res = await _service.GetById(id);
            if (res == null)
            {
                _logger.LogWarning("Data not found");
                return NotFound("Data not found");
            }
            return Ok(res);
        }


        [HttpPost]
        public async Task<IActionResult> InsertDepartment(InsertDepartment insertDepartment)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation("Inserting data...");
                var res = await _service.Insert(insertDepartment);
                if (res == true)
                {
                    _logger.LogInformation("Data inserted successfully");
                    return Ok("Data inserted successfully...");
                }
                else
                {
                    _logger.LogWarning("Something went wrong");
                    return BadRequest("something went wrong");
                }
            }
            else
            {
                return BadRequest("Model state is not valid");
            }
        }


        [HttpPut]
        public async Task<IActionResult> UpdateDepartment(UpdateDepartment updateDepartment)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation("Updating data...");
                var res = await _service.Update(updateDepartment);
                if (res == true)
                {
                    _logger.LogInformation("Data updated...");
                    return Ok("Data updated...");
                }
                else
                {
                    _logger.LogWarning("Something went wrong");
                    return BadRequest("Something went wrong");
                }
            }
            return
                BadRequest("Model state is not valid...!");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDepartment(int Id)
        {
            if (Id != null)
            {
                _logger.LogInformation("Deleting data...");
                var res = await _service.DeleteById(Id);
                if (res == true)
                {
                    _logger.LogInformation("Data deleted...!");
                    return Ok("Data deleted...!");

                }
                else
                {
                    _logger.LogWarning("Something went wrong");
                    return BadRequest("Something went wrong");
                }

            }
            else
            {
                return
                    BadRequest("Id is not found");
            }

        }
    }
}
