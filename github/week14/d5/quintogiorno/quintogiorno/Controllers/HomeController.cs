using Microsoft.AspNetCore.Mvc;
using quintogiorno.Interfaces;
using quintogiorno.Models;
using System.Diagnostics;

namespace quintogiorno.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IProductService productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        private readonly IProductService _productRepository;

        

        public IActionResult Index()
        {
            var products = _productRepository.GetProducts();
            return View(products);

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
    }
}
