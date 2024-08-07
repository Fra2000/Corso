using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PizzeriaWebApp.Models
{
    
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
     
        public int Id { get; set; }

        
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        
        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

       
        [Required]
        [StringLength(100)] 
        public string Password { get; set; }

       
        [Required]
        public string Role { get; set; }

       
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
