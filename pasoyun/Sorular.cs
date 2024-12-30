using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pasoyun
{
    public class Sorular : SoruYoneticisi, ISoruYonetimi1
    {
        private List<string> _soruListesi;
        
        public List<string> SoruListesi 
        { 
            get { return liste; } 
            private set { liste = value; }
        }

        public Sorular()
        {
            SoruListesi = new List<string>
            {
                "Eski dilde insanoğlu ?",//a
                "Misket ?",//b
                "Ağustus böceği ?",//c
                "Kedigillerden kısa mesafelerde dünyanın en hızlı koşan hayvanı ?",//ç
                "Belirli ortak bir amacı gerçekleştirmek için kurulan yasal topluluk",//d
                "Okulda mukavva kağıt gibi şeylerle yapılan çalışmalar ?",//e
                "Rumeli Hisarını hangi padişah yapmıştır ?",//f
                "Umulmadık zamanda umulmadık biçimde olan kaza ?",//g
                "Düzenli entrika ?",//h
                "Eskiden İslam Dünyasının İlim Beşiği Olan Kufe Şehri Hangi Devlet Sınırları İçindedir ?",//ı
                "Magna Carta hangi ülkenin kralıyla yapılmış bir sözleşmedir ?",//i
                "İkinci Dünya Savaşında Hangi Ülkeye Atom Bombası Atılmıştır ?",//j
                "Yolcu bileti denetleyen ve vagon işlerine bakan görevli ?",//k
                "Bulgaristan para birimi ?",//l
                "Maddi ve manevi açılardan ulus ve ülke çıkarlarını her şeyin üstünde tutma alışkanlığına ne ad verilir ?",//m
                "Kaval biçimdeki nefesli çalgı ?",//n
                "Türklerin kuraklık nedeniyle göç ettiği ana yurdu ?",//o
                "Liberalizm neyin üzerine kurulan siyasi felsefe veya dünya görüşüdür",//ö
                "Tamamını kaplayacak şekilde takılan takma saç ?",//p
                "Fas ın başkenti ?",//r
                "Et kesmeye yarayan ağır enli bıçak ?",//s
                "İlk yerli tiyatro eseri kime aittir ?",//ş
                "Akaryakıt ürünlerini taşıyan gemi, kamyon ?",//t
                "Dünya kupasını ilk kez kim kazanmıştır ?",//u
                "karaciğerin proteinin sindirimi sürecinde ürettiği, kanda taşınan ve böbreklerin süzerek kandan çıkardığı atık nedir ?",//ü
                "bir işi yapmak için verilen söz ya da yapılacağına söz verilen şey.",//v
                "Hüküm",//y
                "Ses teli olmayan memeli ?"//z
            };
        }

        public override void ListeyiYukle()
        {
            
        }

        public override string VeriGetir(int index)
        {
            return SoruGetir(index);
        }

        public override bool ListeKontrol()
        {
            return SoruListesi != null && SoruListesi.Count == 28;
        }

        public override string SoruOlustur(string soru)
        {
            return soru + " ?";
        }

        public override bool SoruGecerliMi(string soru)
        {
            return !string.IsNullOrEmpty(soru);
        }

        public string SoruGetir(int index)
        {
            return index >= 0 && index < SoruListesi.Count ? SoruListesi[index] : string.Empty;
        }

        public void SorulariYukle()
        {
            
            ListeyiYukle();
        }

        public override bool SorularHazirMi
        {
            get => SoruListesi != null && SoruListesi.Count == 28;
            set => base.SorularHazirMi = value;
        }

        public override void SorulariHazirla()
        {
            if (!SorularHazirMi)
            {
                SoruListesi = new List<string>
                {
                    "Eski dilde insanoğlu ?",//a
                    "Misket ?",//b
                    "Ağustus böceği ?",//c
                    "Kedigillerden kısa mesafelerde dünyanın en hızlı koşan hayvanı ?",//ç
                    "Belirli ortak bir amacı gerçekleştirmek için kurulan yasal topluluk",//d
                    "Okulda mukavva kağıt gibi şeylerle yapılan çalışmalar ?",//e
                    "Rumeli Hisarını hangi padişah yapmıştır ?",//f
                    "Umulmadık zamanda umulmadık biçimde olan kaza ?",//g
                    "Düzenli entrika ?",//h
                    "Eskiden İslam Dünyasının İlim Beşiği Olan Kufe Şehri Hangi Devlet Sınırları İçindedir ?",//ı
                    "Magna Carta hangi ülkenin kralıyla yapılmış bir sözleşmedir ?",//i
                    "İkinci Dünya Savaşında Hangi Ülkeye Atom Bombası Atılmıştır ?",//j
                    "Yolcu bileti denetleyen ve vagon işlerine bakan görevli ?",//k
                    "Bulgaristan para birimi ?",//l
                    "Maddi ve manevi açılardan ulus ve ülke çıkarlarını her şeyin üstünde tutma alışkanlığına ne ad verilir ?",//m
                    "Kaval biçimdeki nefesli çalgı ?",//n
                    "Türklerin kuraklık nedeniyle göç ettiği ana yurdu ?",//o
                    "Liberalizm neyin üzerine kurulan siyasi felsefe veya dünya görüşüdür",//ö
                    "Tamamını kaplayacak şekilde takılan takma saç ?",//p
                    "Fas ın başkenti ?",//r
                    "Et kesmeye yarayan ağır enli bıçak ?",//s
                    "İlk yerli tiyatro eseri kime aittir ?",//ş
                    "Akaryakıt ürünlerini taşıyan gemi, kamyon ?",//t
                    "Dünya kupasını ilk kez kim kazanmıştır ?",//u
                    "karaciğerin proteinin sindirimi sürecinde ürettiği, kanda taşınan ve böbreklerin süzerek kandan çıkardığı atık nedir ?",//ü
                    "bir işi yapmak için verilen söz ya da yapılacağına söz verilen şey.",//v
                    "Hüküm",//y
                    "Ses teli olmayan memeli ?"//z
                };
                base.SorulariHazirla();
            }
        }

        public override void SoruKontrolEt(string soru)
        {
            throw new NotImplementedException();
        }
    }
}
