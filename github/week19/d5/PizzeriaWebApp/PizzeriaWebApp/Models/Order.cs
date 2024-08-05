using PizzeriaWebApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzeriaWebApp.Models
{
    /// <summary>
    /// Un ordine.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Chiave.
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Data dell'ordine.
        /// </summary>
        public DateTime PlacedAt { get; set; }

        /// <summary>
        /// Utente che ha effettuato l'ordine.
        /// </summary>
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        /// <summary>
        /// Indica se l'ordine è stato evaso.
        /// </summary>
        public bool IsFulfilled { get; set; }

        /// <summary>
        /// Indirizzo di consegna.
        /// </summary>
        [Required]
        [StringLength(80)]
        public string Address { get; set; }

        [StringLength(255)]
        public string Notes { get; set; }

        /// <summary>
        /// Prodotti ordinati.
        /// </summary>
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}
