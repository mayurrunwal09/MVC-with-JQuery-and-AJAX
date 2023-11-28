using BankDetails1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankDetails1.Controllers
{
    public class TransactionController : Controller
    {
       private readonly MainDBContext _dbContext;
        public TransactionController(MainDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            var details = _dbContext.Transaction;
            return View(await details.ToListAsync());   
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            { 
                return NotFound();
            }
            var details = await _dbContext.Transaction.FirstOrDefaultAsync(x=>x.TransactionId==id);
            if(details == null)
            {
                return NotFound();
            }
            return View(details);
        }
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Transaction());
            }
            else
            {
                var details = await _dbContext.Transaction.FirstOrDefaultAsync(x=>x.TransactionId==id);
                if(details == null)
                {
                    return NotFound();
                }
                return View(details);
            }
        }
        [HttpPost]
        [NoDirectAccess]
        public async Task<IActionResult>AddOrEdit(int id, [Bind("TransactionId,AccountNumber,BeneficiaryName,BankName,SWIFTCode,Amount,Date")]Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                if(id == 0)
                {
                    transaction.Date = DateTime.Now;
                    _dbContext.Transaction.Add(transaction);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        _dbContext.Transaction.Update(transaction);
                        await _dbContext.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if(!TransactionModelExist(transaction.TransactionId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _dbContext.Transaction.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", transaction) });
        }

        private bool TransactionModelExist(int transactionId)
        {
            throw new NotImplementedException();
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Delete(int id)
        {
            var transactionModel = await _dbContext.Transaction.FindAsync(id);
            _dbContext.Transaction.Remove(transactionModel);
            await _dbContext.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _dbContext.Transaction.ToList()) });
        }

    }

    }

