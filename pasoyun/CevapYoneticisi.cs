using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pasoyun
{
    public abstract class CevapYoneticisi: OyunYoneticisi
    {
        public virtual bool CevaplarHazirMi { get; protected set; }
        
        public abstract bool CevapKontrol(string kullaniciCevabi, string dogruCevap);
        public abstract string CevapFormati(string cevap);
        
        public virtual void CevaplariSifirla()
        {
            ListeyiTemizle();
            CevaplarHazirMi = false;
        }
    }
}
