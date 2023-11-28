using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OneToMany1.Models;

namespace OneToMany1.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly MainDBContext _dbContext;
        public EmployeesController(MainDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            var emp = _dbContext.Employees.Include(d => d.Department);
            return View(await emp.ToListAsync());   
        }
        public async Task<IActionResult>AddOrEdit(int id = 0)
        {
            if(id == 0)
            {
                ViewData["DepId"] = new SelectList(_dbContext.Departments, "DepId", "DepName");
                return View(new Employee());
            }
            else
            {
                var emp = await _dbContext.Employees.FindAsync(id);
                if (emp == null)
                {
                    return NotFound();
                }
                ViewData["DepId"] = new SelectList(_dbContext.Departments, "DepId", "DepName");
                return View(emp);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>AddOrEdit(int id, [Bind("EmpId,EmpName,Location,DateOfJoining,Gender,State,Country,PostalCode,Education,DepId")]Employee employee)
        {
            if (id == 0)
            {
                ViewData["DepId"] = new SelectList(_dbContext.Departments, "DepId", "DepName");
                _dbContext.Employees.Add(employee);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                try
                {
                    _dbContext.Employees.Update(employee);
                    await _dbContext.SaveChangesAsync();
                }
                catch
                {
                    if (!Employee(employee.EmpId))
                    {
                        ViewData["DepId"] = new SelectList(_dbContext.Departments, "DepId", "DepName");
                        return NotFound();
                    }
                    else
                        throw;
                }
                return Json(new { isValid = true, html = Helper.viewtostring(this, "ViewAll", _dbContext.Employees.ToListAsync()) });
            }
            return Json(new { isValid = false, html = Helper.viewtostring(this, "AddOrEdit", employee) });
        }

        private bool Employee(int empId)
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Delete(int id)
        {
            var emp = await _dbContext.Employees.FindAsync(id);
            _dbContext.Employees.Remove(emp);
            await _dbContext.SaveChangesAsync();
            return Json(new { html = Helper.viewtostring(this, "ViewAll") });
        }
    }
}
