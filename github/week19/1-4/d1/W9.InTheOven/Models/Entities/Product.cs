using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace W9.InTheOven.Models.Entities
{
    /// <summary>
    /// Un prodotto.
    /// </summary>
    public class Product
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
        /// Prezzo.
        /// </summary>
        [Range(0, 100)]
        [Precision(2)]
        public decimal Price { get; set; }
        /// <summary>
        /// Foto.
        /// </summary>
        [Required, StringLength(128)]
        public required byte[] Photo { get; set; }
        /// <summary>
        /// Tempo di consegna in minuti.
        /// </summary>
        [Range(0, 60)]
        public int DeliveryTimeInMinutes { get; set; }
        /// <summary>
        /// Ingredienti di cui è composto il prodotto.
        /// </summary>
        public List<Ingredient> Ingredients { get; set; } = [];
        /// <summary>
        /// Righe di ordini nei quali il prodotto appare.
        /// </summary>
        public List<OrderItem> OrderedItems { get; set; } = [];
    }
}
