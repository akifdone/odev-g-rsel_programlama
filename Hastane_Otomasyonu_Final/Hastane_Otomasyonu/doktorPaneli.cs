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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hastane_Otomasyonu
{
    public partial class doktorPaneli : Form
    {
        public doktorPaneli()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection("Data Source=AKIF;Initial Catalog=HastaneOtomasyonuDb;Integrated Security=True");

        private void button7_Click(object sender, EventArgs e)
        {
            
            
            try
            {
               

                    baglan.Open();
                    SqlCommand sorgulama = new SqlCommand("select * from doktorlar where doktor_id=@id", baglan);
                    sorgulama.Parameters.AddWithValue("@id", label2.Text);
                    SqlDataReader oku = sorgulama.ExecuteReader();
                    if(oku.Read())
                    {
                            doktorbilgi bilgi = new doktorbilgi();
                            bilgi.Show();
                            bilgi.maskedTextBox3.Text = oku[1].ToString();
                            bilgi.maskedTextBox1.Text = oku[5].ToString();
                            bilgi.textBox1.Text = oku[3].ToString();
                            bilgi.textBox6.Text = oku[11].ToString();
                            bilgi.textBox7.Text = oku[6].ToString();
                            bilgi.textBox7.Text = oku[7].ToString();
                            bilgi.maskedTextBox2.Text = oku[8].ToString();
                            bilgi.textBox5.Text = oku[9].ToString();
                            bilgi.maskedTextBox4.Text = oku[2].ToString();
                            bilgi.textBox5.Text = oku[11].ToString();


                    }
                    
                    baglan.Close();
             

            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata!! " + " " + hata);

            }
        }

        public static SqlDataAdapter da;
        public static DataTable dt;
       
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                bekleyenHasta hasta = new bekleyenHasta();
                hasta.Show();
                baglan.Open();
                SqlCommand bekleyen_list = new SqlCommand("select bekleyenHasta.bekleyen_id,klinkler.klinik_adi,doktorlar.doktor_adi_soyadi,hasta.hasta_id from " +
                    "bekleyenHasta INNER JOIN klinkler on bekleyenHasta.bekleyen_klinik_id = klinkler.klinik_id  " +
                    "INNER JOIN doktorlar on bekleyenHasta.bekleyen_doktor_id = doktorlar.doktor_id " +
                    "INNER JOIN hasta on bekleyenHasta.bekleyen_hasta_id = hasta.hasta_id where bekleyenHasta.bekleyen_doktor_id=@id", baglan);
                bekleyen_list.Parameters.AddWithValue("@id", label2.Text);
                da = new SqlDataAdapter(bekleyen_list);
                dt = new DataTable();
                da.Fill(dt);
                hasta.dataGridView1.DataSource = dt;
                baglan.Close();
            }

            catch (Exception hata)
            {

                MessageBox.Show("hata" + "" + hata);
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                randevuGörüntüle randevu = new randevuGörüntüle();

                randevu.Show();

                baglan.Open();

                SqlCommand görüntüle = new SqlCommand("Select randevular.randevu_id,klinkler.klinik_adi,randevular.randevu_tarih,randevular.randevu_saat,hasta.hasta_tc,hasta.hasta_ad,hasta.hasta_soyad,doktorlar.doktor_adi_soyadi from " +
                    "randevular INNER JOIN hasta on randevular.randevu_hasta_id=hasta.hasta_id INNER JOIN klinkler ON randevular.randevu_klinik_id=klinkler.klinik_id INNER JOIN doktorlar ON randevular.randevu_doktor_id = doktorlar.doktor_id where doktorlar.doktor_id=@id", baglan);
                görüntüle.Parameters.AddWithValue("@id", label2.Text);
                da = new SqlDataAdapter(görüntüle);
                dt = new DataTable();
                da.Fill(dt);
                randevu.dataGridView1.DataSource = dt;
                baglan.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show("hata" + " " + ex);
            }
        }

        private void doktorPaneli_Load(object sender, EventArgs e)
        {

        }
    }
}
