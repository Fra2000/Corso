using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace W9.InTheOven.Models.Entities
{
    /// <summary>
    /// Ruolo applicativo.
    /// </summary>
    public class Role
    {
        /// <summary>
        /// Chiave.
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// Nome del ruolo.
        /// </summary>
        [Required]
        [StringLength(50)]
        public required string Name { get; set; }
        /// <summary>
        /// Utenti che appartengono al ruolo.
        /// </summary>
        public List<User> Users { get; set; } = [];
    }
}