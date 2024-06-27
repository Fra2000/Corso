
namespace D_3.Models
{
    public class Sala
    {
        public string Nome { get; set; }
        public int CapienzaMassima { get; set; } = 120;
        public List<Biglietto> BigliettiVenduti { get; set; } = new List<Biglietto>();

        public int BigliettiRidotti => BigliettiVenduti.Count(b => b.Tipo == "Ridotto");
        public int BigliettiTotali => BigliettiVenduti.Count;
    }
}