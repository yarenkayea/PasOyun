using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pasoyun
{
    public abstract class OyunYoneticisi
    {
        protected List<string> liste;

        protected OyunYoneticisi()
        {
            liste = new List<string>();
        }

        public abstract void ListeyiYukle();
        public abstract string VeriGetir(int index);
        public abstract bool ListeKontrol();
        
        public virtual void ListeyiTemizle()
        {
            liste.Clear();
        }
        
        public virtual int ListeUzunluguGetir()
        {
            return liste.Count;
        }
    }
}
