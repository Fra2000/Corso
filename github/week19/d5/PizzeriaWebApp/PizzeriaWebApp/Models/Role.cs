
using System.ComponentModel.DataAnnotations;


namespace PizzeriaWebApp.Models
{
 
    public class Role
    {
       
        public int Id { get; set; }

       
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

       
        public List<User> Users { get; set; } = new List<User>();
    }
}
