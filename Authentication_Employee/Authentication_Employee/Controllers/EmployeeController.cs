using Authentication_Employee.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Authentication_Employee.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly MainDBContext _context;
        public EmployeeController(MainDBContext context)
        {
                _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var emp = await _context.Employees.ToListAsync();
            return View(emp);
        }
    }
}
