using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace W9.InTheOven.Models.Entities
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
        public required string Name { get; set; }
        /// <summary>
        /// Prodotti nei quali l'ingrediente appare.
        /// </summary>
        public List<Product> Products { get; set; } = [];
    }
}