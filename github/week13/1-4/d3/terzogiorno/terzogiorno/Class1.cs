using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace terzogiorno
{
    internal class Class1
    {
       

    public class ContoCorrente
    {
        public string NumeroConto { get; private set; }
        public string Intestatario { get; private set; }
        public decimal Saldo { get; private set; }
        private bool isAperto;

        public ContoCorrente()
        {
            isAperto = false;
            Saldo = 0;
        }

        public void ApriConto(string numeroConto, string intestatario, decimal versamentoIniziale)
        {
            if (isAperto)
            {
                throw new InvalidOperationException("Il conto è già aperto.");
            }

            if (versamentoIniziale < 1000)
            {
                throw new ArgumentException("Il versamento iniziale deve essere almeno di 1000 euro.");
            }

            NumeroConto = numeroConto;
            Intestatario = intestatario;
            Saldo = versamentoIniziale;
            isAperto = true;
            Console.WriteLine("Conto aperto con successo.");
        }

        public void Versamento(decimal importo)
        {
            if (!isAperto)
            {
                throw new InvalidOperationException("Il conto non è ancora stato aperto.");
            }

            if (importo <= 0)
            {
                throw new ArgumentException("L'importo del versamento deve essere positivo.");
            }

            Saldo += importo;
            Console.WriteLine("Versamento effettuato con successo. Saldo attuale: " + Saldo);
        }

        public void Prelievo(decimal importo)
        {
            if (!isAperto)
            {
                throw new InvalidOperationException("Il conto non è ancora stato aperto.");
            }

            if (importo <= 0)
            {
                throw new ArgumentException("L'importo del prelievo deve essere positivo.");
            }

            if (importo > Saldo)
            {
                throw new InvalidOperationException("Saldo insufficiente per effettuare il prelievo.");
            }

            Saldo -= importo;
            Console.WriteLine("Prelievo effettuato con successo. Saldo attuale: " + Saldo);
        }
    }

}
}
