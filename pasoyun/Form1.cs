namespace pasoyun
{
    public partial class Form1 : Form
    {
        private Kayitİslemleri kayitIslemleri;

        public Form1()
        {
            InitializeComponent();
            kayitIslemleri = new Kayitİslemleri();
            
            
            textBox2.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = textBox1.Text.Trim();
            string sifre = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("Kullanıcı adı ve şifre boş bırakılamaz!", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (kayitIslemleri.KullaniciGirisKontrol(kullaniciAdi, sifre))
            {
                Form2 form2gecis = new Form2();
                form2gecis.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KayitForm kayitFormu = new KayitForm();
            kayitFormu.Show();
            this.Hide();
        }
    }
}
