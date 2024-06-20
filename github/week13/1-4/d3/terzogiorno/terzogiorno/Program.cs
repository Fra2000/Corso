using static terzogiorno.Class1;

namespace terzogiorno
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ContoCorrente mioConto = new ContoCorrente();
            ContoCorrente suoConto = new ContoCorrente();

            // Aprire il conto
            mioConto.ApriConto("123456789", "Mario Rossi", 1500);

            // Fare un versamento
            mioConto.Versamento(500);

            // Fare un prelevamento
            mioConto.Prelievo(200);

            // Tentare di aprire il conto di nuovo (lancerà un'eccezione)
            try
            {
                mioConto.ApriConto("987654321", "Luigi Bianchi", 2000);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                suoConto.ApriConto("1234", "Federico", 500);
            }
            catch (ArgumentException ex) { Console.WriteLine(ex.Message); }



            string[] listanomi = { "francesco", "marco", "mario", "chiara", "lorenzo" };
            string nome;
            int i;
            bool verifica = false;

            Console.WriteLine("Inserire il nome da ricercare");
            nome = Console.ReadLine();

            for (i = 0; i < listanomi.Length; i++)
            {
                if (listanomi[i] == nome)
                {
                    Console.WriteLine("Il nome è presente nella lista");
                    verifica = true;
                }

            }
            if (verifica == false)
            {
                Console.WriteLine("Il nome non è presente nella lista");
            }

            



            int x = 0;
            Console.WriteLine("Specifica dimensione array");
            x = int.Parse(Console.ReadLine());
            int[] listanumeri = new int[x];

            int e;
            int somma = 0;

            for (e = 0; e < listanumeri.Length; e++)
            {
                Console.WriteLine("Inserisci numero");
                listanumeri[e] = int.Parse(Console.ReadLine());
            }
            for (e = 0; e < listanumeri.Length; e++)
            {
                somma += listanumeri[e];
            }
            Console.WriteLine($"La somma è: {somma}");
            Console.WriteLine($"La media è: {somma / x}");
            Console.ReadLine();
        }
    }
}
