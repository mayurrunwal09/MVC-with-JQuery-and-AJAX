using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneToManyPopup.Models;

namespace OneToManyPopup.Controllers
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
            var dep = _dbContext.Departments;
            return View(await dep.ToListAsync());
        }
        public async Task<IActionResult>AddOrEdit(int id = 0)
        {

            if(id == 0)
            {
                return View(new Department());
            }
            else
            {
                var dep = await _dbContext.Departments.FirstOrDefaultAsync(x => x.DepId==id);
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
            if(id == 0)
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
                    if(!DepartmentExist(department.DepId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Json(new { isValid = true, html = Helper.viewtostring(this,"_ViewAll",_dbContext.Departments.ToListAsync()) });
            }
            return Json(new {isValid=false,html=Helper.viewtostring(this,"AddOrEdit",department.DepId) });  
        }

        private bool DepartmentExist(int depId)
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
            return Json(new { html = Helper.viewtostring(this, "_ViewAll") });
        }
    }
}
