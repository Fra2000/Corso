using secondogiorno;
using secondogiorno.Services;

internal class Program
{
    private static ICVService _service = new LocalCVService();
    private static void Stampa(CV cv)
    {
        Console.WriteLine("Nome:{0} Cognome: {1}", cv.personalInfo.Name, cv.personalInfo.SurName);
        foreach (var e in cv.Impiego)
        {
            Console.WriteLine(" {2} Dal {0} al {1}", e.Dal, e.Al, e.Azienda);
        }
    }
    private static void Main(string[] args)
    {
        _service.AggiungereTitolostudio(new secondogiorno.TitoloDiStudio
        {
            Al = new DateOnly(1999, 1, 1),
            Dal = new DateOnly(1997, 1, 1),
            Istituto = "Istituto superiore",
            Qualifica = "Diploma",
            Tipo = "Scuola"
        });

        _service.AggiungereTitolostudio(new secondogiorno.TitoloDiStudio
        {
            Al = new DateOnly(2000, 1, 1),
            Dal = new DateOnly(1995, 1, 1),
            Istituto = "Università",
            Qualifica = "Laurea",
            Tipo = "Scuola"
        });

        _service.AggiungereEsperienza(new secondogiorno.Esperienza
        {
            Al = DateOnly.FromDateTime(DateTime.Now),
            Dal = DateOnly.FromDateTime(DateTime.Now.AddYears(-10)),
            Azienda = "Privata",
            Compiti="tuttofare",
            Descrizione="ero un tuttofare",
            JobTitle="tuttofare"

        });

        _service.AggiungereInfopersonali(new secondogiorno.personalInfo
        {
            Phone = 33773535,
            Email="fnrr@debf",
            Name="Fra",
            SurName="Gia"
        });

        var cv = _service.CreaCV();
        Stampa(cv);
    }
}