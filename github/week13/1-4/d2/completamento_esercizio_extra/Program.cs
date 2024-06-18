namespace U1_D2_Riepilogo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NumbersTranslator translator = new NumbersTranslator();
            Console.WriteLine(translator.Translate(0));
            Console.WriteLine(translator.Translate(-10));
            Console.WriteLine(translator.Translate(645));
            Console.WriteLine(translator.Translate(-535));
            for (int i = 1; i < 100; i++)
            {
                Console.WriteLine(translator.Translate(i));
            }
        }
    }
}
