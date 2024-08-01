using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PizzeriaWebApp.Models
{
    /// <summary>
    /// Un utente.
    /// </summary>
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        /// <summary>
        /// Chiave.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome utente.
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// Email.
        /// </summary>
        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        [Required]
        [StringLength(100)] // Puoi aumentare la lunghezza per includere hash della password
        public string Password { get; set; }

        /// <summary>
        /// Ruolo dell'utente.
        /// </summary>
        [Required]
        public string Role { get; set; }

        /// <summary>
        /// Tutti gli ordini di un utente.
        /// </summary>
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
