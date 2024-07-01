using quintogiorno.Models;

namespace quintogiorno.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        void AddProduct(Product product);
    }
}
