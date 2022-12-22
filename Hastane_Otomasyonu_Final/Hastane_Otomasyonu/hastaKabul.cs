using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Hastane_Otomasyonu
{
    public partial class hastaKabul : Form
    {
        public hastaKabul()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=AKIF;Initial Catalog=HastaneOtomasyonuDb;Integrated Security=True");

        void idsorgulama()
        {
            if (baglanti.State == ConnectionState.Open)
                baglanti.Close();
            baglanti.Open();
            SqlCommand id = new SqlCommand("select hasta_id from hasta where hasta_tc=@tc ", baglanti);
            id.Parameters.AddWithValue("@tc", maskedTextBox1.Text);
            SqlDataReader oku = id.ExecuteReader();
            while (oku.Read())
            {
                textBox6.Text = oku[0].ToString();
                textBox7.Text = oku[0].ToString();

            }
            baglanti.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            try
            {
                if (maskedTextBox1.Text != "")
                {
                 
                    baglanti.Open();
                    SqlCommand sorgulama = new SqlCommand("select * from hasta where hasta_tc=@tc", baglanti);
                    sorgulama.Parameters.AddWithValue("@tc", maskedTextBox1.Text);
                    SqlDataReader oku = sorgulama.ExecuteReader();
                    if (oku.Read())
                    {
                        textBox6.Text = oku[0].ToString();
                        textBox7.Text = oku[0].ToString();
                        textBox1.Text = oku[2].ToString();
                        textBox2.Text = oku[3].ToString();
                        comboBox1.Text = oku[4].ToString();
                        comboBox4.Text = oku[5].ToString();
                        comboBox2.Text = oku[6].ToString();
                        maskedTextBox3.Text = oku[7].ToString();
                        textBox3.Text = oku[8].ToString();
                        textBox4.Text = oku[9].ToString();
                        maskedTextBox2.Text = oku[10].ToString();
                        textBox5.Text = oku[11].ToString();
                        richTextBox2.Text = oku[13].ToString();
                        MessageBox.Show("Bu kritere uyan bir hasta bulundu.");
                        
                        

                     }
                    else
                        MessageBox.Show("Bu kriterde bir hasta bulunamadı. Lütfen kayıt yapınız.");
                    baglanti.Close();
                }
                else
                    MessageBox.Show("Önce Hasta TC'si giriniz.");

            }
            catch(Exception hata)
            {
                MessageBox.Show("Hata!! "+" "+ hata);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text != "" && textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && maskedTextBox2.Text != "" && maskedTextBox3.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && comboBox4.Text != "" )
            {
                groupBox1.Enabled = true;
                groupBox2.Enabled = false;
            }
            else
                MessageBox.Show("Önce Hasta Girişi Yapınız");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text != "" && textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && maskedTextBox2.Text != "" && maskedTextBox3.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && comboBox4.Text != "" )
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = true;
            }
            else
                MessageBox.Show("Önce Hasta Girişi Yapınız");
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                string kayit = "insert into hasta (hasta_tc,hasta_ad,hasta_soyad,hasta_cinsiyeti,hasta_kan,hasta_dogumYeri,hasta_dogumTarihi,hasta_babaAdi,hasta_anaAdi,hasta_tel,hasta_posta,hasta_parola,hasta_adres) " +
                "values(@hasta_tc,@hasta_ad,@hasta_soyad,@hasta_cinsiyeti,@hasta_kan,@hasta_dogumYeri,@hasta_dogumTarihi,@hasta_babaAdi,@hasta_anaAdi,@hasta_tel,@hasta_posta,@hasta_parola, @hasta_adres)";
                SqlCommand komut = new SqlCommand(kayit, baglanti);
                komut.Parameters.AddWithValue("@hasta_tc", maskedTextBox1.Text);
                komut.Parameters.AddWithValue("@hasta_ad",textBox1.Text);
                komut.Parameters.AddWithValue("@hasta_soyad",textBox2.Text);
                komut.Parameters.AddWithValue("@hasta_cinsiyeti", comboBox1.Text);
                komut.Parameters.AddWithValue("@hasta_kan", comboBox4.Text);
                komut.Parameters.AddWithValue("@hasta_dogumYeri", comboBox2.Text);
                komut.Parameters.AddWithValue("@hasta_dogumTarihi", maskedTextBox3.Text);
                komut.Parameters.AddWithValue("@hasta_babaAdi", textBox3.Text);
                komut.Parameters.AddWithValue("@hasta_anaAdi", textBox4.Text);
                komut.Parameters.AddWithValue("@hasta_tel", maskedTextBox2.Text);
                komut.Parameters.AddWithValue("@hasta_posta", textBox5.Text);
                komut.Parameters.AddWithValue("@hasta_parola","");
                komut.Parameters.AddWithValue("@hasta_adres",richTextBox2.Text);
               

                komut.ExecuteNonQuery();
                baglanti.Close();

                baglanti.Open();

                SqlCommand sorgulama = new SqlCommand("select * from hasta where hasta_tc=@tc", baglanti);
                sorgulama.Parameters.AddWithValue("@tc", maskedTextBox1.Text);
                SqlDataReader oku = sorgulama.ExecuteReader();
                if (oku.Read())
                {
                    textBox6.Text = oku[0].ToString();
                    textBox7.Text = oku[0].ToString();

                }
                baglanti.Close();
                MessageBox.Show("kayıt eklendi");

              
            }
            catch (Exception hata)
            {

                MessageBox.Show("hatameydan geldi" + "" + hata.Message);



            }
        }

        private void hastaKabul_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'hastaneOtomasyonuDbDataSet.klinkler' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.klinklerTableAdapter.Fill(this.hastaneOtomasyonuDbDataSet.klinkler);
            // TODO: Bu kod satırı 'hastaneOtomasyonuDbDataSet.doktorlar' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.doktorlarTableAdapter.Fill(this.hastaneOtomasyonuDbDataSet.doktorlar);

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                string kayit = "insert into bekleyenHasta (bekleyen_klinik_id,bekleyen_doktor_id,bekleyen_hasta_id) " +
                "values(@klinik_id,@doktor_id,@hasta_id)";
                SqlCommand komut = new SqlCommand(kayit, baglanti);
                komut.Parameters.AddWithValue("@klinik_id", comboBox3.SelectedValue.ToString());
                komut.Parameters.AddWithValue("@doktor_id", comboBox5.SelectedValue.ToString());
                komut.Parameters.AddWithValue("@hasta_id", textBox6.Text);

              

                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Muayene Oluşturuldu");

            }
            catch (Exception hata)
            {

                MessageBox.Show("hatameydan geldi" + "" + hata.Message);



            }
        }
    }
   
}
