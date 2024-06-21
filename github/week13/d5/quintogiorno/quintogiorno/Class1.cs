using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quintogiorno
{
    internal class Class1
    {
        public class Contribuente
        {
            // Proprietà della classe Contribuente
            public string Nome { get; private set; }
            public string Cognome { get; private set; }
            public DateTime DataNascita { get; private set; }
            public string CodiceFiscale { get; private set; }
            public string Sesso { get; private set; }
            public string ComuneResidenza { get; private set; }
            public decimal RedditoAnnuale { get; private set; }

            // Costruttore vuoto della classe Contribuente
            public Contribuente() { }

            // Metodo che serve per salvare i dati nelle proprietà
            public void proprieta(string nome, string cognome, DateTime dataNascita, string codiceFiscale, string sesso, string comuneResidenza, decimal redditoAnnuale)
            {
                Nome = nome;
                Cognome = cognome;
                DataNascita = dataNascita;
                CodiceFiscale = codiceFiscale;
                Sesso = sesso;
                ComuneResidenza = comuneResidenza;
                RedditoAnnuale = redditoAnnuale;
            }


            // Metodo per calcolare l'imposta
            public decimal CalcolaImposta()
            {
                decimal reddito = RedditoAnnuale;
                decimal imposta = 0;

                // Definizione degli scaglioni e delle relative aliquote
                decimal[] limitiScaglioni = { 15000, 28000, 55000, 75000 };
                decimal[] aliquote = { 0.23m, 0.27m, 0.38m, 0.41m, 0.43m };

                // Calcolo dell'imposta utilizzando switch
                switch (reddito)
                {   // Nel caso in cui il reddito è inferiore o uguale a 15000
                    case decimal r1 when r1 <= limitiScaglioni[0]:
                        imposta = reddito * aliquote[0];
                        break;
                    // Nel caso in cui il reddito è inferiore o uguale a 28000
                    case decimal r2 when r2 <= limitiScaglioni[1]:
                        imposta = 3450 + ((reddito - limitiScaglioni[0]) * aliquote[1]);
                        break;
                    // Nel caso in cui il reddito è inferiore o uguale a 55000
                    case decimal r3 when r3 <= limitiScaglioni[2]:
                        imposta = 6960 + ((reddito - limitiScaglioni[1]) * aliquote[2]);
                        break;
                    // Nel caso in cui il reddito è inferiore o uguale a 75000
                    case decimal r4 when r4 <= limitiScaglioni[3]:
                        imposta = 17220 + ((reddito - limitiScaglioni[2]) * aliquote[3]);
                        break;
                    // Nel caso in cui il reddito è superiore a 75000
                    case decimal r5 when r5 > limitiScaglioni[3]:
                        imposta = 25420 + ((reddito - limitiScaglioni[3]) * aliquote[4]);
                        break;
                }

                return imposta;
            }
        }
    }
}
