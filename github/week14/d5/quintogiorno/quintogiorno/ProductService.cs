using quintogiorno.Interfaces;
using quintogiorno.Models;

namespace quintogiorno
{
    public class ProductService : IProductService
    {
        private readonly static List<Product> _products = new List<Product>();
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;

            _products.Add(new Product { Id = 1, Name = "Prodotto A", Price = 10.99m, Description = "descrizione a", ImagePath = "/images/1.jpeg" });
            _products.Add(new Product { Id = 2, Name = "Prodotto B", Price = 5.99m, Description = "descrizione b", ImagePath = "/images/2.jpeg" });
        }

        public void AddProduct(Product product)
        {
            
            int newId = _products.Any() ? _products.Max(p => p.Id) + 1 : 1;
            product.Id = newId;

            
           

            _products.Add(product);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _products;
        }
    }
}
