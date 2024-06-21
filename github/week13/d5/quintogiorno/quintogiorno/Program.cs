using static quintogiorno.Class1;

namespace quintogiorno
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CALCOLO DELL'IMPOSTA DA VERSARE");

            // Creo un nuovo oggetto Contribuente
            Contribuente contribuente = new Contribuente();

            // Richiedo e imposto le proprietà del contribuente
            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Cognome: ");
            string cognome = Console.ReadLine();

            Console.Write("Data di nascita (formato dd/MM/yyyy): ");
            DateTime dataNascita;

            // obbligo l'utente a inserire la data nel formato corretto
            while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataNascita))
            {
                Console.WriteLine("Formato data non valido. Inserisci nel formato dd/MM/yyyy: ");
            }

            Console.Write("Sesso (M/F): ");
            string sesso = Console.ReadLine().ToUpper();

            //obbligo l'utente a inserire il formato corretto
            while (sesso != "M" && sesso != "F")
            {
                Console.WriteLine("Inserisci solo M per Maschio o F per Femmina: ");
                sesso = Console.ReadLine().ToUpper();
                if (sesso == "M" || sesso == "F") break;
            }
            

            Console.Write("Comune di residenza: ");
            string comuneResidenza = Console.ReadLine();

            Console.Write("Codice Fiscale: ");
            string codiceFiscale = Console.ReadLine();

            Console.Write("Reddito annuale: ");
            decimal redditoAnnuale;

            // anche in questo caso mi assicuro che l'utente inserisca un valore nel formato corretto
            while (!decimal.TryParse(Console.ReadLine(), out redditoAnnuale))
            {
                Console.WriteLine("Inserisci un valore numerico per il reddito annuale: ");
            }

            // Imposta le proprietà del contribuente con i valori inseriti
            contribuente.proprieta(nome, cognome, dataNascita, codiceFiscale, sesso, comuneResidenza, redditoAnnuale);

            // Calcola l'imposta da versare
            decimal impostaDaPagare = contribuente.CalcolaImposta();

            // Stampa il riepilogo
            Console.WriteLine();
            Console.WriteLine($"Contribuente: {contribuente.Nome} {contribuente.Cognome},");
            Console.WriteLine($"nato il {contribuente.DataNascita.ToString("dd/MM/yyyy")} ({contribuente.Sesso}),");
            Console.WriteLine($"residente in {contribuente.ComuneResidenza},");
            Console.WriteLine($"codice fiscale: {contribuente.CodiceFiscale}");
            Console.WriteLine();
            Console.WriteLine($"Reddito dichiarato: {contribuente.RedditoAnnuale}");
            Console.WriteLine();
            Console.WriteLine($"IMPOSTA DA VERSARE: {impostaDaPagare}");

            Console.ReadLine(); // Attende la pressione di un tasto per chiudere la console

        }
    }
}
