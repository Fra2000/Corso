using Microsoft.AspNetCore.Mvc;
using primogiorno.Models;
using System.Diagnostics;

namespace primogiorno.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        
        public IActionResult Index()
        {
            return View(menu); // Passa il menu alla vista
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private static List<foodItem> menu = new List<foodItem>
        {
            new foodItem { Id = 1, Name = "Coca Cola 150 ml", Price = 2.50m },
            new foodItem { Id = 2, Name = "Insalata di pollo", Price = 5.20m },
            new foodItem { Id = 3, Name = "Pizza Margherita", Price = 10.00m },
            new foodItem { Id = 4, Name = "Pizza 4 Formaggi", Price = 12.50m },
            new foodItem { Id = 5, Name = "Pz patatine fritte", Price = 3.50m },
            new foodItem { Id = 6, Name = "Insalata di riso", Price = 8.00m },
            new foodItem { Id = 7, Name = "Frutta di stagione", Price = 5.00m },
            new foodItem { Id = 8, Name = "Pizza fritta", Price = 5.00m },
            new foodItem { Id = 9, Name = "Piadina vegetariana", Price = 6.00m },
            new foodItem { Id = 10, Name = "Panino Hamburger", Price = 7.90m }
        };


        public IActionResult Order(int id)
        {
            var item = menu.Find(i => i.Id == id);
            if (item != null)
            {
                // Logica per aggiungere l'elemento all'ordine
                ViewBag.Message = $"{item.Name} aggiunto al conto.";
            }

            return RedirectToAction("Index");
        }
    }
}
