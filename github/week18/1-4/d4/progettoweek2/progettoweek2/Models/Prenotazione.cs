namespace progettoweek2.Models
{
    public class Prenotazione
    {
        public int ID { get; set; }
        public DateTime DataPrenotazione { get; set; }
        public int NumeroProgressivoAnno { get; set; }
        public int Anno { get; set; }
        public DateTime DataInizio { get; set; }
        public DateTime DataFine { get; set; }
        public decimal Caparra { get; set; }
        public decimal Tariffa { get; set; }
        public string ServizioCamera { get; set; }
    }
}
