using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hastane_Otomasyonu
{
    public partial class doktorgiris : Form
    {
        public doktorgiris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection baglan = new SqlConnection("Data Source=AKIF;Initial Catalog=HastaneOtomasyonuDb;Integrated Security=True");

                if (textBox1.Text == "" || textBox2.Text == "")
                {

                    MessageBox.Show("Lütfen Gerekli Bilgileri Giriniz");

                }
                else
                {
                    baglan.Open();
                    SqlCommand cmd = new SqlCommand("Select * from  doktorlar where  kullanici_adi = @kullanici AND sifre = @pass", baglan);
                    cmd.Parameters.AddWithValue("@kullanici", textBox1.Text);
                    cmd.Parameters.AddWithValue("@pass", textBox2.Text);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        doktorPaneli dktpanel = new doktorPaneli();
                        dktpanel.label4.Text = textBox1.Text.ToString();
                        dktpanel.label2.Text = dr["doktor_id"].ToString();
                        dktpanel.label11.Text = dr["doktor_adi_soyadi"].ToString();
                        dktpanel.label13.Text = dr["doktor_tc"].ToString();

                        MessageBox.Show("tebrikler giriş yaptınız");
                        
                        dktpanel.Show();
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
