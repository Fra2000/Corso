namespace progettoweek2.Models
{
    public class PrenotazioniServiziAggiuntivi
    {
        public int ID { get; set; }
        public int PrenotazioneID { get; set; }
        public int ServizioAggiuntivoID { get; set; }

        public Prenotazione Prenotazione { get; set; }
        public ServizioAggiuntivo ServizioAggiuntivo { get; set; }
    }
}
