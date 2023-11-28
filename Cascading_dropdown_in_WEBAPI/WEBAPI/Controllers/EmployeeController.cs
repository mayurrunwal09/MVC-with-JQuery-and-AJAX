using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Repository_And_Services.Context;
using Repository_And_Services.Repository;
using Repository_And_Services.Services.Custom.DepartmentServices;
using Repository_And_Services.Services.Custom.EmployeeServices;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly MainDBContext _dbContext;
        private readonly IEmployeeService _employee;
        private readonly IDepartmentService _department;
        private readonly ILogger<EmployeeController> _logger;
        private readonly IRepositroy<Country> _country;
        private readonly IRepositroy<State> _state;
        private readonly IRepositroy<City> _city;

        public EmployeeController(MainDBContext context, IRepositroy<Country> country,IRepositroy<State> state,IRepositroy<City> city,IEmployeeService employee, IDepartmentService department, ILogger<EmployeeController> logger)
        {
            _dbContext = context;
            _employee = employee;
            _department = department;
            _logger = logger; // Correct the logger parameter name
            _country = country;
            _state = state;
            _city = city;

        }

        [HttpGet(nameof(GetAllEmployee))]
        public async Task<IActionResult> GetAllEmployee()
        {
            try
            {
                _logger.LogInformation("Getting all the data...!");
                var res = await _employee.GetAll();
                if (res.Count == 0) // Check if the result is an empty list
                {
                    _logger.LogWarning("Data not found...!");
                    return NotFound("Data not found...!"); // Return NotFound instead of BadRequest
                }
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all data");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }


       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            try
            {
                _logger.LogInformation("Getting employee data");
                var res = await _employee.GetById(id);
                if (res == null)
                {
                    _logger.LogWarning("Data not found");
                    return NotFound("Employee data not found");
                }
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting employee data");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
        [HttpPost]
        public async Task<IActionResult> InsertEmployee([FromForm] InsertEmployee insertEmployee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Check if an employee with the same EmployeeId already exists
                    var existingEmployee = await _employee.Find(e => e.EmployeeId == insertEmployee.EmployeeId);
                    if (existingEmployee != null)
                    {
                        _logger.LogWarning("Employee with the same EmployeeId already exists.");
                        return BadRequest("Employee with the same EmployeeId already exists.");
                    }

                    // You can add additional validation logic if needed

                    _logger.LogInformation("Inserting Data....!");
                    var result = await _employee.Insert(insertEmployee);

                    if (result)
                    {
                        _logger.LogInformation("Data Inserted Successfully.....!");
                        return Ok("Data Inserted Successfully.....!");
                    }
                    else
                    {
                        _logger.LogWarning("Something Went Wrong.....!");
                        return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong.....!");
                    }
                }
                else
                {
                    _logger.LogWarning("Model state is not valid.");
                    return BadRequest("Model state is not valid.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while inserting employee data");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }


     



        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployee updateEmployee) // Use [FromBody] for JSON data
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logger.LogInformation("Updating Data...!");
                    var result = await _employee.Update(updateEmployee);
                    if (result == true)
                    {
                        _logger.LogInformation("Data Updated Successfully ...... !");
                        return Ok("Data Updated Successfully ...... !");
                    }
                    else
                    {
                        _logger.LogWarning("Something Went Wrong.....!");
                        return StatusCode(StatusCodes.Status500InternalServerError, "Something went Wrong...... !");
                    }
                }
                return BadRequest("Model state is not valid");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating employee data");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id != 0) // Check if id is not zero
                {
                    _logger.LogInformation("Deleting Data...!");
                    var result = await _employee.Delete(id);
                    if (result == true)
                    {
                        _logger.LogInformation("Data Deleted Successfully....!");
                        return Ok("Data Deleted Successfully....!");
                    }
                    else
                    {
                        _logger.LogWarning("Something Went Wrong.....!");
                        return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong......!");
                    }
                }
                else
                {
                    return BadRequest("Id was not Found");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting employee data");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }





        [HttpGet("GetAllCountries")]
        public async Task<IActionResult> GetAllCountries()
        {
            try
            {
                var countries = await _country.GetAll();
                return Ok(countries);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting countries");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpGet(nameof(GetAllStates))]
        public async Task<IActionResult> GetAllStates()
        {
            try
            {
                var states = await _state.GetAll();
                return Ok(states);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting countries");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpGet(nameof(GetAllCity))]
        public async Task<IActionResult> GetAllCity()
        {
            try
            {
                var states = await _city.GetAll();
                return Ok(states);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting countries");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        

       

    }
}
