using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace quintogiorno.Models
{
    [Table("TIPO_VIOLAZIONE")]
    public class TipoViolazione
    {
        [Key]
        public int IDViolazione { get; set; }

        [Required]
        [StringLength(500)]
        public string Descrizione { get; set; }
    }
}
