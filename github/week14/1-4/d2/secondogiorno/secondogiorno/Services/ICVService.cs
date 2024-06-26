using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace secondogiorno.Services
{
    public interface ICVService
    {
        void AggiungereTitolostudio(TitoloDiStudio titoloDiStudio);
        void AggiungereEsperienza(Esperienza esperienza);
        void AggiungereInfopersonali(personalInfo personalInfo);

        CV CreaCV();
    }
}
