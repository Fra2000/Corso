using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace secondogiorno.Services
{
    public class LocalCVService : ICVService
    {
        private readonly static CV cv = new CV();
        public void AggiungereEsperienza(Esperienza esperienza)
        {
            cv.Impiego.Add(esperienza);
        }

        public void AggiungereInfopersonali(personalInfo personalInfo)
        {
            cv.personalInfo = personalInfo;
        }

        public void AggiungereTitolostudio(TitoloDiStudio titoloDiStudio)
        {
            cv.Studio.Add(titoloDiStudio);
        }

        public CV CreaCV()
        {
            return cv;
        }
    }
}
