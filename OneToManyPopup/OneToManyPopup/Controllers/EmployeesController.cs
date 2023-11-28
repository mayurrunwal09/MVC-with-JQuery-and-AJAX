using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OneToManyPopup.Models;

namespace OneToManyPopup.Controllers
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
            var emp = await _dbContext.Employees.Include(d => d.Department).ToListAsync();
            return View(emp);
        }
        public async Task<IActionResult>AddOrEdit(int id=0)
        {
            if(id == 0)
            {
                ViewData["DepId"] = new SelectList(_dbContext.Departments, "DepId", "DepName");
                return View(new Employee());
            }
            else
            {
                var emp = await _dbContext.Employees.FindAsync(id);
                if(emp == null)
                {
                    return NotFound();
                }
                ViewData["DepId"] = new SelectList(_dbContext.Departments, "DepId", "DepName");
                return View(emp);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>AddOrEdit(int id, [Bind("EmpId,EmpName,Location,DateOfJoining,DepId,")]Employee employee)
        {
            if(id==0)
            {
                ViewData["DepId"] = new SelectList(_dbContext.Departments, "DepId", "DepName", employee.DepId);
                _dbContext.Employees.Add(employee);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                try
                {
                    ViewData["DepId"] = new SelectList(_dbContext.Departments, "DepId", "DepName", employee.DepId);

                    _dbContext.Update(employee);
                    await _dbContext.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if(!ExployeeExist(employee.EmpId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Json(new { isValid = true,html = Helper.viewtostring(this,"_ViewAll",_dbContext.Employees.ToListAsync()) });
            }
            return Json(new { isValid = false, html = Helper.viewtostring(this, "AddOrEdit", employee) });
        }

        private bool ExployeeExist(int empId)
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Delete(int id)
        {
            var emp = await _dbContext.Employees.Include(d => d.Department).FirstOrDefaultAsync(x => x.EmpId == id);
            _dbContext.Employees.Remove(emp);
            await _dbContext.SaveChangesAsync();
            return Json(new { html = Helper.viewtostring(this, "_ViewAll", emp) });
        }
    }
}
