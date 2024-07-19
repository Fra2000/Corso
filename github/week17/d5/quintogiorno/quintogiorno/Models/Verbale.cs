using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace quintogiorno.Models
{
    [Table("VERBALE")]
    public class Verbale
    {
        
        public int IDVerbale { get; set; }
        public DateTime DataViolazione { get; set; }
        public string IndirizzoViolazione { get; set; }
        public string Nominativo_Agente { get; set; }
        public DateTime DataTrascrizioneVerbale { get; set; }
        public decimal Importo { get; set; }
        public int DecurtamentoPunti { get; set; }
        public int? IDAnagrafica { get; set; }
        public Anagrafica Anagrafica { get; set; }
        public int? IDViolazione { get; set; }
        public TipoViolazione TipoViolazione { get; set; }
    }
}
