using System.Reflection.Metadata;

namespace secondogiorno
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Persona primaPersona = new Persona("Francesco", "Giannini", 24);

           // primaPersona.getNome = "marco"; es1

            primaPersona.getDescrizione();
            Console.WriteLine(primaPersona.getDescrizione());

            primaPersona.ersona();
            Console.WriteLine(primaPersona.ersona());


            primaPersona.ersona("francesco");
            Console.WriteLine(primaPersona.ersona("francesco"));
        }
    }
}
