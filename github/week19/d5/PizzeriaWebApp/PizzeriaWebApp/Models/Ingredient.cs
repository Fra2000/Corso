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
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Denominazione.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();

        // Questa lista non è necessaria nel modello Ingredient stesso
        // ma la relazione sarà configurata nel DbContext per associare più ingredienti a più prodotti
    }
}
