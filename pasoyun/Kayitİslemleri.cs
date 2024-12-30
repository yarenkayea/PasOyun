using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace pasoyun
{
    public class Kayitİslemleri
    {
        private string connectionString = @"Data Source=VICTUS\SQLEXPRESS04;Initial Catalog=PasOyun;Integrated Security=True;TrustServerCertificate=True";

        public Kayitİslemleri()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString.Replace("Database=pasoyun", "Database=master")))
                {
                    conn.Open();
                    
                    
                    using (SqlCommand cmd = new SqlCommand("CREATE DATABASE IF NOT EXISTS pasoyun", conn))
                    {
                        try { cmd.ExecuteNonQuery(); } catch { }
                    }
                }
                VeritabaniniOlustur();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı başlatma hatası: " + ex.Message);
            }
        }

        private void VeritabaniniOlustur()
        {
            
            string masterConnection = @"Data Source=VICTUS\SQLEXPRESS05;Initial Catalog=PasOyun;Integrated Security=True;TrustServerCertificate=True";

            try
            {
                
                using (SqlConnection conn = new SqlConnection(masterConnection))
                {
                    conn.Open();

                    
                    string createDbQuery = "IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'PasOyun') CREATE DATABASE PasOyun;";
                    using (SqlCommand cmd = new SqlCommand(createDbQuery, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string createTableQuery = @"
                        IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Kullanicilar')
                        CREATE TABLE Kullanicilar (
                            ID INT IDENTITY(1,1) PRIMARY KEY,
                            Ad NVARCHAR(50),
                            Soyad NVARCHAR(50),
                            KullaniciAdi NVARCHAR(50) UNIQUE,
                            Sifre NVARCHAR(50),
                            Yas INT
                        )";

                    using (SqlCommand cmd = new SqlCommand(createTableQuery, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı oluşturma hatası: " + ex.Message);
            }
        }

        public bool KullaniciKaydet(string ad, string soyad, string kullaniciAdi, string sifre, int yas)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    
                    
                    string kontrolSorgu = "SELECT COUNT(*) FROM Kullanicilar WHERE KullaniciAdi = @kullaniciAdi";
                    using (SqlCommand kontrolCmd = new SqlCommand(kontrolSorgu, conn))
                    {
                        kontrolCmd.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                        int kayitSayisi = (int)kontrolCmd.ExecuteScalar();
                        
                        if (kayitSayisi > 0)
                        {
                            MessageBox.Show("Bu kullanıcı adı zaten kullanılıyor!");
                            return false;
                        }
                    }

                    
                    string insertSorgu = @"INSERT INTO Kullanicilar (Ad, Soyad, KullaniciAdi, Sifre, Yas) 
                                         VALUES (@ad, @soyad, @kullaniciAdi, @sifre, @yas)";

                    using (SqlCommand cmd = new SqlCommand(insertSorgu, conn))
                    {
                        cmd.Parameters.AddWithValue("@ad", ad);
                        cmd.Parameters.AddWithValue("@soyad", soyad);
                        cmd.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                        cmd.Parameters.AddWithValue("@sifre", sifre);
                        cmd.Parameters.AddWithValue("@yas", yas);

                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt sırasında bir hata oluştu: " + ex.Message);
                return false;
            }
        }

        public bool KullaniciGirisKontrol(string kullaniciAdi, string sifre)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sorgu = "SELECT COUNT(*) FROM Kullanicilar WHERE KullaniciAdi = @kullaniciAdi AND Sifre = @sifre";
                    
                    using (SqlCommand cmd = new SqlCommand(sorgu, conn))
                    {
                        cmd.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                        cmd.Parameters.AddWithValue("@sifre", sifre);

                        int sonuc = (int)cmd.ExecuteScalar();
                        return sonuc > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Giriş kontrolü sırasında bir hata oluştu: " + ex.Message);
                return false;
            }
        }
    }
}
