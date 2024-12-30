using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pasoyun
{
    public partial class Form2 : Form
    {
        public Sorular sorular = null!;
        public Cevaplar cevaplar = null!;
        private int mevcutsoruIndex = -1;
        private List<Button> harfButonlari = null!;
        private bool tumSorularCevaplandi = false;
        private readonly List<int> pasGecilmisSorular = new();
        private readonly List<int> cevaplanmisSorular = new();

        public Form2()
        {
            InitializeComponent();
            sorular = new Sorular();
            cevaplar = new Cevaplar();
            harfButonlari = new List<Button>();

            richTextBox1.Text = "Pasaparolla oyununa hoşgeldiniz";
            richTextBox2.Visible = false;
            richTextBox3.Text = "";
            linkLabel1.Text = "başla";
            linkLabel2.Visible = false;

            HarfButonlariniYukle();
            richTextBox3.KeyPress += RichTextBox3_KeyPress;
            

            
            
        }

        private void HarfButonlariniYukle()
        {
            harfButonlari = Controls.OfType<Button>()
                .OrderBy(b => b.Text)
                .ToList();

            foreach (Button btn in harfButonlari)
            {
                btn.BackColor = SystemColors.Control;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (linkLabel1.Text == "başla")
            {
                mevcutsoruIndex = 0;
                linkLabel1.Text = "cevapla";
                linkLabel2.Visible = true;

                SoruyuGoster();
            }
            else
            {
                CevabiKontrolEt();
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PasGec();
        }

        private void SoruyuGoster()
        {
            if (mevcutsoruIndex >= 0 && mevcutsoruIndex < sorular.SoruListesi.Count)
            {
                richTextBox1.Text = sorular.SoruListesi[mevcutsoruIndex];
                richTextBox2.Visible = false;
                richTextBox3.Clear();
            }
        }

        private void CevabiKontrolEt()
        {
            if (cevaplar == null || cevaplar.CevapListesi == null || mevcutsoruIndex < 0 || mevcutsoruIndex >= cevaplar.CevapListesi.Count)
            {
                MessageBox.Show("Cevaplar doğru yüklenmedi veya geçersiz bir soru indeksi.");
                return;
            }

            string kullaniciCevabi = richTextBox3.Text.Trim().ToLower();
            string dogruCevap = cevaplar.CevapListesi[mevcutsoruIndex].ToLower();

            if (String.Equals(kullaniciCevabi, dogruCevap, StringComparison.OrdinalIgnoreCase))
            {
                harfButonlari[mevcutsoruIndex].BackColor = Color.Green;
                richTextBox2.Visible = false;
            }
            else
            {
                harfButonlari[mevcutsoruIndex].BackColor = Color.Red;
                richTextBox2.Text = cevaplar.CevapListesi[mevcutsoruIndex];
                richTextBox2.Visible = true;
            }

            if (!cevaplanmisSorular.Contains(mevcutsoruIndex))
            {
                cevaplanmisSorular.Add(mevcutsoruIndex);
            }
            pasGecilmisSorular.Remove(mevcutsoruIndex);

            richTextBox3.Clear();
            Application.DoEvents();
            System.Threading.Thread.Sleep(1500);

            SonrakiSoruyaGec();
        }

        private void PasGec()
        {
            if (!cevaplanmisSorular.Contains(mevcutsoruIndex))
            {
                harfButonlari[mevcutsoruIndex].BackColor = Color.Yellow;
                if (!pasGecilmisSorular.Contains(mevcutsoruIndex))
                {
                    pasGecilmisSorular.Add(mevcutsoruIndex);
                }
            }
            SonrakiSoruyaGec();
        }

        private void SonrakiSoruyaGec()
        {
            const int TOPLAM_SORU = 28; 

            
            int dogruSayisi = harfButonlari.Count(b => b.BackColor == Color.Green);
            int yanlisSayisi = harfButonlari.Count(b => b.BackColor == Color.Red);
            int toplamCevaplanan = dogruSayisi + yanlisSayisi;

            
            Console.WriteLine($"Toplam cevaplanan: {toplamCevaplanan}, Doğru: {dogruSayisi}, Yanlış: {yanlisSayisi}");

            
            if (toplamCevaplanan == TOPLAM_SORU)
            {
                SonucuGoster();
                return;
            }

            
            bool soruBulundu = false;
            int baslangicIndex = mevcutsoruIndex;

            
            for (int i = baslangicIndex + 1; i < TOPLAM_SORU; i++)
            {
                if (harfButonlari[i].BackColor == SystemColors.Control || 
                    harfButonlari[i].BackColor == Color.Yellow)
                {
                    mevcutsoruIndex = i;
                    soruBulundu = true;
                    break;
                }
            }

            
            if (!soruBulundu)
            {
                for (int i = 0; i < baslangicIndex; i++)
                {
                    if (harfButonlari[i].BackColor == SystemColors.Control || 
                        harfButonlari[i].BackColor == Color.Yellow)
                    {
                        mevcutsoruIndex = i;
                        soruBulundu = true;
                        break;
                    }
                }
            }

            
            if (soruBulundu)
            {
                SoruyuGoster();
                return;
            }

            
            if (!soruBulundu && toplamCevaplanan == TOPLAM_SORU)
            {
                SonucuGoster();
            }
        }

        private void SonucuGoster()
        {
            tumSorularCevaplandi = true;
            int toplamSoru = harfButonlari.Count;
            int dogruSayisi = harfButonlari.Count(b => b.BackColor == Color.Green);
            int yanlisSayisi = harfButonlari.Count(b => b.BackColor == Color.Red);

            string sonucMesaji = Sonuc.SonucMesajiGetir(dogruSayisi);

            string mesaj = $"Oyun bitti!\n\n" +
                           $"Toplam Soru: {toplamSoru}\n" +
                           $"Doğru Sayısı: {dogruSayisi}\n" +
                           $"Yanlış Sayısı: {yanlisSayisi}\n\n" +
                           $"{sonucMesaji}";

            MessageBox.Show(mesaj, "Sonuç", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            Form1 form1 = new Form1();
            form1.Show();
            Close();
        }

        private void RichTextBox3_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                if (linkLabel1.Text == "cevapla" && !string.IsNullOrEmpty(richTextBox3.Text))
                {
                    CevabiKontrolEt();
                }
            }
        }
    }
}
