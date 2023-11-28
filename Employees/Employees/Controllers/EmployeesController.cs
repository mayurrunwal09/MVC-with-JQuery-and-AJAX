using Employees.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employees.Controllers
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
            var emp = _dbContext.Employees;
            return View(await emp.ToListAsync());
        }
        [HttpGet]

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var emp = await _dbContext.Employees.FirstOrDefaultAsync(x=>x.EmpId==id);
            if(emp == null)
            {
                return NotFound();
            }
            return View(emp);   
        }
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Employee());
            }
            else
            {
                var details = await _dbContext.Employees.FirstOrDefaultAsync(x => x.EmpId == id);
                if (details == null)
                {
                    return NotFound();
                }
                return View(details);
            }
        }
        [HttpPost]
        [NoDirectAccess]
      
        public async Task<IActionResult> AddOrEdit(int id, [Bind("EmpId,EmpName,Location,DepId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                   
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
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!EmployeeExist(employee.EmpId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _dbContext.Employees.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", employee) });
        }

        private bool EmployeeExist(int transactionId)
        {
            throw new NotImplementedException();
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _dbContext.Employees.FindAsync(id);
            _dbContext.Employees.Remove(employee);
            await _dbContext.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _dbContext.Employees.ToList()) });
        }

        


    }
    
}