namespace U1_D2_Riepilogo
{
    internal class NumbersTranslator
    {
        public string Translate(int number)
        {
            // possiamo pensare a tre diversi casi iniziali:
            // 1. il numero è = 0
            if (number == 0)
            {
                // 1.1. allora restituisco direttamente "zero"
                return "zero";
            }
            // 2. il numero è negativo
            else if (number < 0)
            {
                // 2.1. allora restituisco la stringa "meno "
                //      alla quale aggiungo la traduzione del numero cambiato di segno
                return "meno " + //qualcosaltro
                                 TranslateNumber(-number);
            }
            // 3. il numero è positivo
            else
            {
                // 3.1. allora devo procedere alla traduzione effettiva...
                return TranslateNumber(number); //qualcosaltro;
            }
        }

        string TranslateNumber(int number)
        {
            // se per caso il numero è 0 restituisco una stringa vuota...
            if (number == 0) return "";
            // qui sono sicuro che number > 0!!!
            // 1. se il numero è < 20
            if (number < 20)
            {
                // 1.1. non ho scelta: devo semplicemente scrivere la sua forma italiana
                // 1.1.1. i numeri da 1 a 20 hanno un formato particolare:
                string[] n = {"uno", "due","tre","quattro","cinque","sei","sette","otto",
                    "nove","dieci","undici","dodici","tredici","quattordici","quindici","sedici",
                    "diciassette","diciotto","diciannove" };
                return n[number - 1];
            }
            // 2. se il numero è < 100
            else if (number < 100)
            {
                // 2.1. prendo le decine
                int dec = number / 10;
                // 2.2. prendo le unità
                int un = number % 10;
                // 2.3. la traduzione delle decine avviene attraverso la corrispondenza
                //      del nome della decina con il valore passato
                string[] d = {"venti","trenta","quaranta","cinquanta","sessanta","settanta",
                    "ottanta","novanta" };
                string decina = d[dec - 2];
                // 2.4. la traduzione delle unità viene effettuata come nel caso del numero < 20
                string unita = TranslateNumber(un);
                return decina + unita;
            }
            else if(number < 1000)
            {
                //prendo le centinaia
                int cent = number / 100;
                //prendo le decine
                int decf = number % 100;
                int dec = decf / 10;
                //prendo le unità
                int un = decf % 10;
                string[] c = { "cento", "duecento", "trecento", "quattrocento", "cinquecento", "seicento", "settecento", "ottocento", "novecento" };
                string centinaia = c[cent - 1];
                string decun = TranslateNumber(decf);
                return centinaia + decun;
            }
            

            // 0. se non posso più tradurre
            // restituisco "overflow"
            return "overflow";
        }
    }
}
