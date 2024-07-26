namespace progettoweek2.Models
{
    public class ServizioAggiuntivo
    {
        public int ID { get; set; }
        public DateTime DataServizio { get; set; }
        public int Quantita { get; set; }
        public decimal Prezzo { get; set; }
        public string Tipologia { get; set; }
    }
}
