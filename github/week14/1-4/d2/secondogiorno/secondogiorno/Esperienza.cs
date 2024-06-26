using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace secondogiorno
{
    public class Esperienza
    {
        public string Azienda { get; set; }
        public string JobTitle { get; set; }
        public DateOnly Dal {  get; set; }
        public DateOnly Al {  get; set; }
        public string Descrizione { get; set; }
        public string Compiti { get; set; }
    }   
}
