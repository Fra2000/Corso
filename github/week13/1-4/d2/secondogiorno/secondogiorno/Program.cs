namespace secondogiorno
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Persona francesco = new Persona("Francesco", "Giannini",24);
            francesco.getDescrizione();
            Console.WriteLine(francesco.getDescrizione());
        }
    }
}
