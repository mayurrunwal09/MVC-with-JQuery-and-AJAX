using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RailwaySystem.Models;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;

namespace RailwaySystem.Controllers
{
    public class RailwaysController : Controller
    {
        private readonly MainDBContext _dbContext;
        public RailwaysController(MainDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            var rail = _dbContext.Railways;
            return View(await rail.ToListAsync());
        }
        public async Task<IActionResult>AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Railway());
            }
            else
            {
                var details = await _dbContext.Railways.FirstOrDefaultAsync(x => x.TrainId == id);
                if (details == null)
                {
                    return NotFound();
                }
                return View(details);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [NoDirectAccess]
        public async Task<IActionResult>AddOrEdit(int id, [Bind("TrainId,TrainNo,TrainName,Schedule,Source,Destination")]Railway railway)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {

                    _dbContext.Add(railway);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        _dbContext.Update(railway);
                        await _dbContext.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TrainExist(railway.TrainId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return Json(new { isValid = true, html = Helper.viewtostring(this, "_ViewAll", _dbContext.Railways.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.viewtostring(this, "AddOrEdit", railway) });
        }

        private bool TrainExist(int trainId)
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var rail = await _dbContext.Railways.FindAsync(id);
            _dbContext.Railways.Remove(rail);
            await _dbContext.SaveChangesAsync();
            return Json(new { html = Helper.viewtostring(this, "_ViewAll", _dbContext.Railways.ToList()) });
        }
    }
}
