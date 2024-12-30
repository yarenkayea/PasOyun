using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pasoyun
{
    public class Cevaplar : CevapYoneticisi, ICevapYonetimi
    {
        public List<string> CevapListesi 
        { 
            get { return liste; } 
            private set { liste = value; }
        }

        public Cevaplar()
        {
            CevapListesi = new List<string>
            {
                "ademoğlu",
                "bilye",
                "cırcır böceği",
                "çita",
                "dernek",
                "el işi",
                "fatih sultan mehmet",
                "görünmez kaza",
                "hile",
                "ırak",
                "ingiltere",
                "japonya",
                "kondüktör",
                "leva",
                "milliyetçilik",
                "ney",
                "orta asya",
                "özgürlük",
                "peruk",
                "rabat",
                "satır",
                "şinasi",
                "tanker",
                "uruguay",
                "üre",
                "vaat",
                "yargı",
                "zürafa"
            };
        }

        public override void ListeyiYukle()
        {
            
        }

        public override string VeriGetir(int index)
        {
            return index >= 0 && index < CevapListesi.Count ? CevapListesi[index] : string.Empty;
        }

        public override bool ListeKontrol()
        {
            return CevapListesi != null && CevapListesi.Count == 28;
        }

        public override bool CevapKontrol(string kullaniciCevabi, string dogruCevap)
        {
            return string.Equals(kullaniciCevabi.Trim(), dogruCevap.Trim(), 
                StringComparison.OrdinalIgnoreCase);
        }

        public override string CevapFormati(string cevap)
        {
            return cevap.Trim().ToLower();
        }

        public void CevaplariYukle()
        {
            
            ListeyiYukle();
        }

        public bool CevapKontrolEt(string kullaniciCevabi, string dogruCevap)
        {
            return CevapKontrol(kullaniciCevabi, dogruCevap);
        }

        public override bool CevaplarHazirMi 
        { 
            get => CevapListesi != null && CevapListesi.Count > 0;
            protected set => base.CevaplarHazirMi = value;
        }

        public override void CevaplariSifirla()
        {
            base.CevaplariSifirla();
            CevapListesi = new List<string>();
        }

        public override int ListeUzunluguGetir()
        {
            return CevapListesi?.Count ?? 0;
        }
    }
}
