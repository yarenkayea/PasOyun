using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pasoyun
{
    public abstract class SoruYoneticisi : OyunYoneticisi
    {
        private bool sorularYuklendi;
        
        public abstract string SoruOlustur(string soru);
        public abstract bool SoruGecerliMi(string soru);
        
        public virtual bool SorularHazirMi
        {
            get => sorularYuklendi;
            set => sorularYuklendi = value;
        }
        
        public virtual void SorulariHazirla()
        {
            ListeyiYukle();
            sorularYuklendi = true;
        }

        public virtual void SorulariGuncelle()
        {
            if (!sorularYuklendi)
            {
                SorulariHazirla();
            }
        }

        public abstract void SoruKontrolEt(string soru);
    }
}
