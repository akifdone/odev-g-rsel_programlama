using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace Hastane_Otomasyonu
{
    public partial class yöneticigiris : Form
    {
        public yöneticigiris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection baglan = new SqlConnection(@"Data Source=AKIF;Initial Catalog=HastaneOtomasyonuDb;Integrated Security=True");

                if (textBox1.Text == "" || textBox2.Text == "")
                {

                    MessageBox.Show("Lütfen Gerekli Bilgileri Giriniz");

                }
                else
                {
                    baglan.Open();
                    SqlCommand cmd = new SqlCommand("Select * from  yönetici where  kullanici_adi = @kullanici AND kullanici_sifre = @pass", baglan);
                    cmd.Parameters.AddWithValue("@kullanici", textBox1.Text);
                    cmd.Parameters.AddWithValue("@pass", textBox2.Text);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        MessageBox.Show("tebrikler giriş yaptınız");
                        yönetici admin = new yönetici();
                        admin.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("hatalı giriş yaptınız");
                    }
                }

            }
            catch (Exception hata)
            {

                MessageBox.Show("hatameydan geldi" + " " + hata.Message);
            }
        }
    }
}
