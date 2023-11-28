using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Service;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        #region Property 
        private readonly IService<LoginUser> _loginUserService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<LoginController> _logger;
        #endregion
        #region  Constuctor
        public LoginController(IService<LoginUser> loginUserService, IWebHostEnvironment webHostEnvironment, ILogger<LoginController> logger)
        {
            _logger = logger;
            _loginUserService = loginUserService;
            _webHostEnvironment = webHostEnvironment;
        }
        #endregion
        #region  GET API : api/Get a specific User of the company
        [HttpGet(nameof(GetUser))]
        public IActionResult GetUser(int id)
        {
            var result = _loginUserService.Get(id);
            if(result != null) {
                return Ok(result);
            }
            return BadRequest("No Records Found");
        }
        #endregion 
        #region  POST API:api/Insert a new User in Company
        [HttpPost(nameof(InsertUser))]
        public IActionResult InsertUser(LoginUser loginUser)
        {
            loginUser.UserLastLoginIpAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
            _loginUserService.Insert(loginUser);
            return Ok(loginUser);
        }
        #endregion
        #region  PUT API:api/Update a existing User in Company
        [HttpPut(nameof(UpdateUser))]
        public IActionResult UpdateUser(LoginUser loginUser)
        {
            loginUser.UserLastLoginIpAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
            _loginUserService.Update(loginUser);
            return Ok(loginUser);
        }
        #endregion
        #region  DELETE API:api/Delete a specific User in Company
        [HttpDelete(nameof(DeleteUser))]
        public IActionResult DeleteUser(int id)
        {
            _loginUserService.Delete(id);
            return Ok(id);
        }
        #endregion
    }
}
