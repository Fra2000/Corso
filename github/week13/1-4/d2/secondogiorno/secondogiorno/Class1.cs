using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace secondogiorno
{
    internal class Persona
    {
        private string nome;
        private string cognome;
        private byte eta;


        public string getNome { get { return nome; } set { this.nome = value; } }
        public string getCognome { get { return cognome; } set { this.cognome = value; } }
        public byte getEta { get { return eta; } set { this.eta = value; } }

        public Persona(string getNome, string getCognome, byte getEta)
        {
            this.nome = getNome;
            this.cognome = getCognome;
            this.eta = getEta;
        }
        public string getDescrizione()
        {

            return "Il nome di questa persona è " + nome + " ed il suo cognome è " + cognome + " di anni " + eta;
        }
    }
}
