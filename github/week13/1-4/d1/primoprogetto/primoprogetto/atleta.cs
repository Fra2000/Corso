using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace primoprogetto
{
    internal class Atleta
    {
        string nome;
        string cognome;
        int numero;

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public string Cognome
        {
            get { return cognome; }
            set { cognome = value; }
        }
    }
}