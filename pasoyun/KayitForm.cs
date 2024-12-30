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
    public partial class KayitForm : Form
    {
        public KayitForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string ad = textBox1.Text.Trim();
            string soyad = textBox2.Text.Trim();
            string kullaniciAdi = textBox3.Text.Trim();
            string sifre = textBox4.Text.Trim();
            
            
            if (string.IsNullOrEmpty(ad) || string.IsNullOrEmpty(soyad) || 
                string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre) || 
                string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz!", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            if (!int.TryParse(textBox5.Text, out int yas))
            {
                MessageBox.Show("Yaş alanına geçerli bir sayı giriniz!", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            Kayitİslemleri kayitIslemleri = new Kayitİslemleri();
            if (kayitIslemleri.KullaniciKaydet(ad, soyad, kullaniciAdi, sifre, yas))
            {
                MessageBox.Show("Kayıt başarıyla tamamlandı!", "Bilgi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                
                Form1 anaForm = new Form1();
                anaForm.Show();
                this.Close();
            }
        }
    }
}
