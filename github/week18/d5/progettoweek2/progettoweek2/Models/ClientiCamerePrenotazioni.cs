namespace progettoweek2.Models
{
    public class ClientiCamerePrenotazioni
    {
        public int ID { get; set; }
        public int ClientiCamereID { get; set; }
        public int PrenotazioniServiziID { get; set; }

        // Opzionalmente, puoi includere riferimenti ai modelli correlati
        public ClientiCamere ClientiCamere { get; set; }
        public PrenotazioniServiziAggiuntivi PrenotazioniServiziAggiuntivi { get; set; }
    }
}
