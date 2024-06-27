

namespace D_3.Models
{
    public static class CinemaData
    {
        public static List<Sala> Sale { get; set; } = new List<Sala>
        {
            new Sala { Nome = "SALA NORD" },
            new Sala { Nome = "SALA EST" },
            new Sala { Nome = "SALA SUD" }
        };
    }
}