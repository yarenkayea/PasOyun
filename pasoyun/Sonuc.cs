using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pasoyun
{
    public class Sonuc
    {
        public static string SonucMesajiGetir(int dogruSayisi)
        {
            string mesaj = "";
            
            if (dogruSayisi == 28)
            {
                mesaj = "Bilginin ta kendisi!";
            }
            else if (dogruSayisi >= 20 && dogruSayisi <= 27)
            {
                mesaj = "Bilgilisin tamam!";
            }
            else if (dogruSayisi >= 15 && dogruSayisi <= 19)
            {
                mesaj = "Bilgin var!";
            }
            else if (dogruSayisi >= 9 && dogruSayisi <= 14)
            {
                mesaj = "Bil...";
            }
            else
            {
                mesaj = "yorumsuzum!";
            }
            
            return mesaj;
        }
    }
}
