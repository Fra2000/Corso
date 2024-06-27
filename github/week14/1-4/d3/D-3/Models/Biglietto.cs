using System.ComponentModel.DataAnnotations;

namespace D_3.Models
{
    public class Biglietto
    {
        [Required(ErrorMessage ="il nome è obbligatorio")]
    public string Nome { get; set; }


        [Required(ErrorMessage = "Il cognome è obbligatorio.")]
        public string Cognome { get; set; }
        [Required(ErrorMessage = "Seleziona una sala.")]
        public string Sala { get; set; }

        [Required(ErrorMessage = "Seleziona un tipo di biglietto.")]
        public string Tipo  { get; set; }







    }
}
