using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzeriaWebApp.Data;
using PizzeriaWebApp.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace PizzeriaWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly PizzeriaDbContext _context;
        private readonly ILogger<AdminController> _logger;

        public AdminController(PizzeriaDbContext context, ILogger<AdminController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new ProductViewModel
            {
                Products = await _context.Products.Include(p => p.Ingredients).ToListAsync(),
                Ingredients = await _context.Ingredients.ToListAsync()
            };
            return View("~/Views/Account/Admin.cshtml", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductViewModel model, int[] selectedIngredients)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation("ModelState is valid. Creating product.");
                var product = model.NewProduct;
                if (selectedIngredients != null)
                {
                    product.Ingredients = new List<Ingredient>();
                    foreach (var ingredientId in selectedIngredients)
                    {
                        var ingredient = await _context.Ingredients.FindAsync(ingredientId);
                        if (ingredient != null)
                        {
                            product.Ingredients.Add(ingredient);
                        }
                    }
                }

                _context.Add(product);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Product created successfully.");
                return RedirectToAction(nameof(Index));
            }

            _logger.LogWarning("ModelState is invalid. Errors: {Errors}", ModelState.Values.SelectMany(v => v.Errors));
            model.Products = await _context.Products.Include(p => p.Ingredients).ToListAsync();
            model.Ingredients = await _context.Ingredients.ToListAsync();
            return View("~/Views/Account/Admin.cshtml", model);
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(ProductViewModel model, int[] selectedIngredients)
        {
            if (ModelState.IsValid)
            {
                var existingProduct = await _context.Products.Include(p => p.Ingredients).FirstOrDefaultAsync(p => p.Id == model.EditProduct.Id);
                if (existingProduct == null)
                {
                    _logger.LogWarning("Product with ID {ProductId} not found.", model.EditProduct.Id);
                    return NotFound();
                }

                existingProduct.Name = model.EditProduct.Name;
                existingProduct.Photo = model.EditProduct.Photo;
                existingProduct.Price = model.EditProduct.Price;
                existingProduct.DeliveryTimeInMinutes = model.EditProduct.DeliveryTimeInMinutes;

                existingProduct.Ingredients.Clear();
                if (selectedIngredients != null)
                {
                    foreach (var ingredientId in selectedIngredients)
                    {
                        var ingredient = await _context.Ingredients.FindAsync(ingredientId);
                        if (ingredient != null)
                        {
                            existingProduct.Ingredients.Add(ingredient);
                        }
                    }
                }

                try
                {
                    _context.Update(existingProduct);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation("Product with ID {ProductId} updated successfully.", existingProduct.Id);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(model.EditProduct.Id))
                    {
                        _logger.LogWarning("Product with ID {ProductId} no longer exists.", model.EditProduct.Id);
                        return NotFound();
                    }
                    else
                    {
                        _logger.LogError("Concurrency error when updating product with ID {ProductId}.", existingProduct.Id);
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            _logger.LogWarning("ModelState is invalid. Errors: {Errors}", ModelState.Values.SelectMany(v => v.Errors));
            model.Products = await _context.Products.Include(p => p.Ingredients).ToListAsync();
            model.Ingredients = await _context.Ingredients.ToListAsync();
            return View("~/Views/Account/Admin.cshtml", model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Product with ID {ProductId} deleted successfully.", id);
            }
            else
            {
                _logger.LogWarning("Product with ID {ProductId} not found.", id);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> CreateIngredient(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation("ModelState is valid. Creating ingredient.");
                _context.Add(model.NewIngredient);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Ingredient created successfully.");
                return RedirectToAction(nameof(Index));
            }

            _logger.LogWarning("ModelState is invalid. Errors: {Errors}", ModelState.Values.SelectMany(v => v.Errors));
            model.Products = await _context.Products.Include(p => p.Ingredients).ToListAsync();
            model.Ingredients = await _context.Ingredients.ToListAsync();
            return View("~/Views/Account/Admin.cshtml", model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteIngredient(int id)
        {
            var ingredient = await _context.Ingredients.FindAsync(id);
            if (ingredient != null)
            {
                _context.Ingredients.Remove(ingredient);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Ingredient with ID {IngredientId} deleted successfully.", id);
            }
            else
            {
                _logger.LogWarning("Ingredient with ID {IngredientId} not found.", id);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
