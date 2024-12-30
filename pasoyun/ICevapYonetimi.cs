using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pasoyun
{
    public interface ICevapYonetimi
    {
        List<string> CevapListesi { get; }
        void CevaplariYukle();
        bool CevapKontrolEt(string kullaniciCevabi, string dogruCevap);
    }
}
