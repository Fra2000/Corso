using quintogiorno.Interfaces;
using quintogiorno.Models;


namespace quintogiorno
{
    public class  ProductRepository : IProductRepository
    {
        private readonly static List<Product> _products = new List<Product>();
        public ProductRepository()
        {
            

            _products.Add(new Product { Id = 1, Name = "Prodotto A", Price = 10.99m, Description = "descrizione a" });
            _products.Add(new Product { Id = 2, Name = "Prodotto B", Price = 5.99m, Description = "descrizione b" });
        }
        public void AddProduct(Product product)
        {
            
            _products.Add(product);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _products;
        }
    }
}
