using PizzeriaWebApp.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzeriaWebApp.Models
{
    /// <summary>
    /// Ruolo applicativo.
    /// </summary>
    public class Role
    {
        /// <summary>
        /// Chiave.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome del ruolo.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Utenti che appartengono al ruolo.
        /// </summary>
        public List<User> Users { get; set; } = new List<User>();
    }
}
