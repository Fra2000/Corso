using Microsoft.AspNetCore.Mvc;
using PizzeriaWebApp.Data;
using PizzeriaWebApp.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.IO;

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

        // Dashboard Amministrativa
        public IActionResult Admin()
        {
            _logger.LogInformation("Navigating to Admin Dashboard.");
            return View("~/Views/Account/Admin.cshtml");
        }

        // Gestione Prodotti
        public async Task<IActionResult> AdminProduct()
        {
            _logger.LogInformation("Navigating to AdminProduct.");
            var viewModel = new AdminProductViewModel
            {
                Products = await _context.Products.Include(p => p.Ingredients).ToListAsync(),
                Ingredients = await _context.Ingredients.ToListAsync()
            };
            return View("~/Views/Account/AdminProduct.cshtml", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdminProduct(AdminProductViewModel viewModel, IFormFile Photo, int[] selectedIngredients)
        {
            _logger.LogInformation("AdminProduct POST method called.");

            ModelState.Remove("NewIngredient.Name");
            ModelState.Remove("NewIngredient.Description");

            if (ModelState.IsValid && viewModel.NewProduct != null)
            {
                _logger.LogInformation("ModelState is valid. Attempting to add new product.");

                // Gestione del file caricato
                if (Photo != null && Photo.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await Photo.CopyToAsync(memoryStream);
                        // Converti l'array di byte in una stringa Base64
                        viewModel.NewProduct.Photo = Convert.ToBase64String(memoryStream.ToArray());
                    }
                }
                else
                {
                    ModelState.AddModelError("NewProduct.Photo", "The Photo field is required.");
                    viewModel.Products = await _context.Products.Include(p => p.Ingredients).ToListAsync();
                    viewModel.Ingredients = await _context.Ingredients.ToListAsync();
                    return View("~/Views/Account/AdminProduct.cshtml", viewModel);
                }

                if (selectedIngredients != null && selectedIngredients.Length > 0)
                {
                    foreach (var ingredientId in selectedIngredients)
                    {
                        var ingredient = await _context.Ingredients.FindAsync(ingredientId);
                        if (ingredient != null)
                        {
                            viewModel.NewProduct.Ingredients.Add(ingredient);
                        }
                    }
                }

                _context.Products.Add(viewModel.NewProduct);
                await _context.SaveChangesAsync();
                _logger.LogInformation("New product saved successfully.");
                return RedirectToAction("AdminProduct");
            }
            else
            {
                _logger.LogWarning("ModelState is invalid. Errors: {Errors}", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
            }

            viewModel.Products = await _context.Products.Include(p => p.Ingredients).ToListAsync();
            viewModel.Ingredients = await _context.Ingredients.ToListAsync();
            return View("~/Views/Account/AdminProduct.cshtml", viewModel);
        }

        // Gestione Ingredienti
        public async Task<IActionResult> AdminIngredient()
        {
            _logger.LogInformation("Navigating to AdminIngredient.");
            var viewModel = new AdminProductViewModel
            {
                Ingredients = await _context.Ingredients.ToListAsync()
            };
            return View("~/Views/Account/AdminIngredient.cshtml", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdminIngredient(AdminProductViewModel viewModel)
        {
            _logger.LogInformation("AdminIngredient POST method called.");

            ModelState.Remove("NewProduct.Name");
            ModelState.Remove("NewProduct.Photo");
            ModelState.Remove("NewProduct.Price");
            ModelState.Remove("NewProduct.DeliveryTimeInMinutes");

            if (ModelState.IsValid && viewModel.NewIngredient != null)
            {
                _logger.LogInformation("ModelState is valid. Adding new ingredient: {@NewIngredient}", viewModel.NewIngredient);
                _context.Ingredients.Add(viewModel.NewIngredient);
                await _context.SaveChangesAsync();
                _logger.LogInformation("New ingredient saved successfully.");
                return RedirectToAction("AdminIngredient");
            }
            

            viewModel.Ingredients = await _context.Ingredients.ToListAsync();
            return View("~/Views/Account/AdminIngredient.cshtml", viewModel);
        }
    }
}
