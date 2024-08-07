using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzeriaWebApp.Models
{
    
    public class Order
    {
       
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

       
        public DateTime PlacedAt { get; set; }

        
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        
        public bool IsFulfilled { get; set; }

        
        [Required]
        [StringLength(80)]
        public string Address { get; set; }

        [StringLength(255)]
        public string Notes { get; set; }

        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}
