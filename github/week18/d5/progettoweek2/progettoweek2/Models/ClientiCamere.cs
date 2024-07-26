namespace progettoweek2.Models
{
    public class ClientiCamere
    {
        public int ID { get; set; }
        public int ClienteID { get; set; }
        public int CameraID { get; set; }

        public Cliente Cliente { get; set; }
        public Camera Camera { get; set; }
    }
}
