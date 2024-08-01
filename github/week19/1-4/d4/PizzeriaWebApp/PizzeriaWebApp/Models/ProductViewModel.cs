using System.Collections.Generic;

namespace PizzeriaWebApp.Models
{
    public class ProductViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public Product NewProduct { get; set; }
        public Product EditProduct { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public Ingredient NewIngredient { get; set; }
    }
}
