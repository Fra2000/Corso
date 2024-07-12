using _1BW_BE.Models;


namespace _1BW_BE.Service
{
    public interface IProductService
    {
        // Gestione dei prodotti
        void CreateProduct(Product product, IEnumerable<IFormFile> imageFiles);
        void DeleteProduct(int productId);
        void UpdateProduct(Product product, IEnumerable<IFormFile> imageFiles = null); 
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int productId);

        // Gestione delle immagini dei prodotti
        IEnumerable<ProductImage> GetImagesByProductId(int productId);
        void AddImageToProduct(int productId, IFormFile imageFile);
        void DeleteImage(int imageId);
        IEnumerable<Product> SearchProducts(string query);
    }
}
