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
        }
    }
}
