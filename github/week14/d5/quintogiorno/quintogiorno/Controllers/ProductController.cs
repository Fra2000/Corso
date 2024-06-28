using Microsoft.AspNetCore.Mvc;
using quintogiorno.Interfaces;
using quintogiorno.Models;

namespace quintogiorno.Controllers
{

        public class ProductController : Controller
        {
            private readonly IProductRepository _productRepository;

            public ProductController(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }

           

            public IActionResult Add()
            {
                return View();
            }

            [HttpPost]
            public IActionResult Add(Product product)
            {    if (ModelState.IsValid)
            {
                _productRepository.AddProduct(product);
                return RedirectToAction("Index", "Home");
                
            }
            return View(product);
            }

        }

}

