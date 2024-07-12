namespace _1BW_BE.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }
        public string Seller { get; set; }
        public bool Available { get; set; }
        public int Quantity { get; set; }
        public List<ProductImage> Images { get; set; }
    }
}
