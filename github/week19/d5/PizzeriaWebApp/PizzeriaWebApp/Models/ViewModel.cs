namespace PizzeriaWebApp.Models
{
    public class AdminProductViewModel
    {
        public AdminProductViewModel()
        {
            NewProduct = new Product();
            NewIngredient = new Ingredient();
            Products = new List<Product>();
            Ingredients = new List<Ingredient>();
        }

        public Product NewProduct { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public Ingredient NewIngredient { get; set; }
        public IEnumerable<Ingredient> Ingredients { get; set; }
    }
}
