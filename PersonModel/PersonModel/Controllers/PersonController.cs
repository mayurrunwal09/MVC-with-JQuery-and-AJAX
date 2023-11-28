using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonModel.Models;
using System.Security.AccessControl;
using System.Text.Json;

namespace PersonModel.Controllers
{
    public class PersonController : Controller
    {
        private readonly MainDBContext _dbContext;
        public PersonController(MainDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            var per = _dbContext.Persons;
            return View(await per.ToListAsync());
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if(id== null)
            {
                return NotFound();
            }
            var per = await _dbContext.Persons.FirstOrDefaultAsync(x=>x.PersonId==id);
            if(per == null)
            {
                return NotFound();
            }
            return View(per);
        }
        public async Task<IActionResult>AddOrEdit(int id=0)
        {
            if(id==0)
            {
                return View(new Person());
            }
            else
            {
                var per = await _dbContext.Persons.FirstOrDefaultAsync(x=>x.PersonId == id);
               if(per == null)
                {
                    return NotFound();
                }
               return View(per);
            }
        }
        [HttpPost]
        [NoDirectAccess]
        public async Task<IActionResult>AddOrEdit(int id, [Bind("PersonId,personName,PersonAge,Gender,Contactno,Location")]Person person)
        {
            if(ModelState.IsValid)
            {
                if (id == 0)
                {
                    _dbContext.Persons.Add(person);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        _dbContext.Persons.Update(person);
                        await _dbContext.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!PersonExist(person.PersonId))
                        {
                            return NotFound();
                        }
                        else { throw; }
                    }
                    
                }
                return Json(new { isValid = true, html = Helper.RenderRozerViewToString(this, "Index", _dbContext.Persons.ToListAsync()) });
                
            }
            return Json(new { isValid = false, html = Helper.RenderRozerViewToString(this, "AddOrEdit", person) });
        }

        private bool PersonExist(int personId)
        {
            throw new NotImplementedException();
        }

       
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var emp = await _dbContext.Persons.FindAsync(id);
            _dbContext.Persons.Remove(emp);
            await _dbContext.SaveChangesAsync();
            return Json(new { html = Helper.RenderRozerViewToString(this, "Index") });

        }
    }
}
