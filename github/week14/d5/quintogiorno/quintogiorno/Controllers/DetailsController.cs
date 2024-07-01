using Microsoft.AspNetCore.Mvc;
using quintogiorno.Interfaces;


namespace quintogiorno.Controllers
{
    public class DetailsController : Controller
    {
        private readonly IProductService _productRepository;

        public DetailsController(IProductService productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index(int id)
        {
            var product = _productRepository.GetProducts().FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View("Details",product);
        }
    }
}
