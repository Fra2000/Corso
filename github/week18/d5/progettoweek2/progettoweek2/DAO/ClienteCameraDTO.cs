namespace progettoweek2.DAO
{
    public class ClienteCameraDTO
    {
        public ClienteDTO Cliente { get; set; }
        public CameraDTO Camera { get; set; }
    }

    public class ClienteDTO
    {
        public string CodiceFiscale { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Citta { get; set; }
        public string Provincia { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Cellulare { get; set; }
        public DateTime DataNascita { get; set; }
    }

    public class CameraDTO
    {
        public int NumeroCamera { get; set; }
        public string Descrizione { get; set; }
        public string Tipologia { get; set; }
    }

}
