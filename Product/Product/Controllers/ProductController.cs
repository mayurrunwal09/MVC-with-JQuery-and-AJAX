using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product.Models;

namespace ProductModel.Controllers
{
    public class ProductController : Controller
    {
        private readonly MainDBContext _dbContext;
        public ProductController(MainDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            var pr = _dbContext.Products;
            return View(await pr.ToListAsync());
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var pr = await _dbContext.Products.FirstOrDefaultAsync(x=>x.ProductId == id);
            if(pr == null)
            {
                return NotFound();
            }
            return View(pr);
        }
        public async Task<IActionResult>AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Product());
            }
            else
            {
                var pr = await _dbContext.Products.FirstOrDefaultAsync(x => x.ProductId == id);
                if(pr == null) { return NotFound(); }
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>AddOrEdit(int id, [Bind("ProductId,ProductName")]Product product)
        {
            if(ModelState.IsValid)
            {
                _dbContext.Products.Add(product);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                try
                {
                    _dbContext.Products.Update(product);
                    await _dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExist(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

            }
        }

        private bool ProductExist(object productId)
        {
            throw new NotImplementedException();
        }
    }
}
