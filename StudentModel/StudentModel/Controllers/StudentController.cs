using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentModel.Models;
using static StudentModel.Helper;

namespace StudentModel.Controllers
{
    public class StudentController : Controller
    {
        private readonly MainDBContext _dbContext;
        public StudentController(MainDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            var stud = _dbContext.Students;
            return View(await stud.ToListAsync());
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var stud = await _dbContext.Students.FirstOrDefaultAsync(x => x.StudentId == id);
            if (stud == null)
            {
                return NotFound();
            }
            return View(stud);
        }
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Student());
            }
            else
            {
                var stud = await _dbContext.Students.FirstOrDefaultAsync(x => x.StudentId == id);
                if (stud == null)
                {
                    return NotFound();
                }
                return View(stud);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("StudentId,StudentName,StudentAge,Gender,Address,Contactno")] Student student)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _dbContext.Students.Add(student);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    try
                    {

                        _dbContext.Students.Update(student);
                        await _dbContext.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!StudentExist(student.StudentId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return Json(new { isValid = true, html = Helper.viewstring(this, "_ViewAll", _dbContext.Students.ToList()) });
            }
            return Json(new { isvalid = false, html = Helper.viewstring(this, "AddOrEdit", student) });
        }

        private bool StudentExist(int studentId)
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Delete(int id)
        {
            var stud = await _dbContext.Students.FirstOrDefaultAsync(x=>x.StudentId==id);
            _dbContext.Students.Remove(stud);
            await _dbContext.SaveChangesAsync();
            return Json(new {html = Helper.viewstring(this,"_ViewAll",_dbContext.Students.ToList())});  
        }
    }
}
