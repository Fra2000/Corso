using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace secondogiorno
{
    internal class Persona
    {
        // proprietà
        private string nome;
        private string cognome;
        private byte eta;
    
        // metodi, questi servono a modificare le proprietà (es1)
        public string getNome { get { return nome; } set { this.nome = value; } }
        public string getCognome { get { return cognome; } set { this.cognome = value; } }
        public byte getEta { get { return eta; } set { this.eta = value; } }

        //costruttori
        public Persona(string nome) { this.nome = nome; }
        public Persona(string nome, string cognome, byte eta)
        {
            this.nome = nome;
            this.cognome = cognome;
            this.eta = eta;
        }


        // altri metodi, che si possono vedere applicati nel Program
        public string getDescrizione()
        { return "Il nome di questa persona è " + nome + " ed il suo cognome è " + cognome + " di anni " + eta; }
        public string ersona() { return "ciao"; }
        public string ersona(string nome) { return "ciao " + nome; }
    } 

}