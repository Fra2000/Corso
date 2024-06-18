namespace secondogiorno
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Persona francesco = new Persona("Francesco", "Giannini",24);
            string descrizione = francesco.getDescrizione();
            Console.WriteLine(descrizione);
        }
    }
}
