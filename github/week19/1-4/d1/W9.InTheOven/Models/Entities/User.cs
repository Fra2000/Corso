using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace W9.InTheOven.Models.Entities
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
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// Nome utente.
        /// </summary>
        [Required]
        [StringLength(20)]
        public required string Name { get; set; }
        /// <summary>
        /// Email.
        /// </summary>
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        /// <summary>
        /// Password.
        /// </summary>
        [Required]
        [StringLength(20)]
        public required string Password { get; set; }
        /// <summary>
        /// Ruoli utente.
        /// </summary>
        public List<Role> Roles { get; set; } = [];
        /// <summary>
        /// Tutti gli ordini di un utente.
        /// </summary>
        public List<Order> Orders { get; set; } = [];
    }
}
