namespace primoprogetto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Atleta primoAtleta = new Atleta();
            primoAtleta.Numero = 5;
            primoAtleta.Nome = "Paolo";


            Console.WriteLine(primoAtleta.Numero);
            Console.WriteLine(primoAtleta.Nome);

        }
    }
}
