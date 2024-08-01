using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzeriaWebApp.Models
{
    /// <summary>
    /// Ingredienti per i prodotti.
    /// </summary>
    [Index(nameof(Name), IsUnique = true)]
    public class Ingredient
    {
        /// <summary>
        /// Chiave.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Denominazione.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Prodotti nei quali l'ingrediente appare.
        /// </summary>
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
