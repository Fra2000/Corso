namespace progettoweek2.Models
{
    public class Dipendente
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Ruolo { get; set; }
    }
}
