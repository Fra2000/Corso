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
            public string Nome { get; set; }
            public string Cognome { get; set; }
            public DateTime DataNascita { get; set; }
            public string CodiceFiscale { get; set; }
            public string Sesso { get; set; }
            public string ComuneResidenza { get; set; }
            public decimal RedditoAnnuale { get; set; }

            // Costruttore della classe Contribuente
            public Contribuente() { }

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
                {
                    case decimal r1 when r1 <= limitiScaglioni[0]:
                        imposta = reddito * aliquote[0];
                        break;
                    case decimal r2 when r2 <= limitiScaglioni[1]:
                        imposta = 3450 + ((reddito - limitiScaglioni[0]) * aliquote[1]);
                        break;
                    case decimal r3 when r3 <= limitiScaglioni[2]:
                        imposta = 6960 + ((reddito - limitiScaglioni[1]) * aliquote[2]);
                        break;
                    case decimal r4 when r4 <= limitiScaglioni[3]:
                        imposta = 17220 + ((reddito - limitiScaglioni[2]) * aliquote[3]);
                        break;
                    case decimal r5 when r5 > limitiScaglioni[3]:
                        imposta = 25420 + ((reddito - limitiScaglioni[3]) * aliquote[4]);
                        break;
                }

                return imposta;
            }
        }
    }
}
