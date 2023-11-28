using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneToMany1.Models;

namespace OneToMany1.Controllers
{
    public class DepartmentsController : Controller
    {
      private readonly MainDBContext _dbContext;
        public DepartmentsController(MainDBContext dbContext)
        {
            _dbContext = dbContext;
        }   
        public async Task<IActionResult> Index()
        {
            var dep = await _dbContext.Departments.ToListAsync();
            return View(dep);   
        }
        public async Task<IActionResult>AddOrEdit(int id = 0)
        {
            if(id == 0)
            {
                return View(new Department());
            }
            else
            {
                var dep = await _dbContext.Departments.FindAsync(id);
                if(dep == null)
                {
                    return NotFound();
                }
                return View(dep);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>AddOrEdit(int id,Department department)
        {
            if (id == 0)
            {
                _dbContext.Departments.Add(department);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                try
                {
                    _dbContext.Departments.Update(department);
                    await _dbContext.SaveChangesAsync();
                }
                catch
                {
                    if (!Department(department.DepId))
                    {
                        return NotFound();
                    }
                    else
                        throw;
                }
                return Json(new { isValid = true, html = Helper.viewtostring(this, "ViewAll", _dbContext.Departments.ToListAsync()) });
            }
            return Json(new { isValid = false, html = Helper.viewtostring(this, "AddOrEdit", department) });
        }

        private bool Department(int depId)
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Delete(int id)
        {
            var dep = await _dbContext.Departments.FindAsync(id);
            _dbContext.Departments.Remove(dep);
            await _dbContext.SaveChangesAsync();
            return Json(new { html = Helper.viewtostring(this, "ViewAll") });
        }
    }
}
