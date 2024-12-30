using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pasoyun
{
    public interface ISoruYonetimi1
    {
        List<string> SoruListesi { get; }
        void SorulariYukle();
        string SoruGetir(int index);
    }
}
