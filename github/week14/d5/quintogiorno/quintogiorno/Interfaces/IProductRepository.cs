using quintogiorno.Models;

namespace quintogiorno.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        void AddProduct(Product product);
    }
}
