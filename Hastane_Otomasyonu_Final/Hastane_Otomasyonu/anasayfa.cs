using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hastane_Otomasyonu
{
    public partial class anasayfa : Form
    {
        public anasayfa()
        {
            InitializeComponent();
        }

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {

        }
        SqlConnection baglan = new SqlConnection("Data Source=AKIF;Initial Catalog=HastaneOtomasyonuDb;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
           doktorgiris dktgiris = new doktorgiris();
            dktgiris.Show();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hastagiris hstgiris = new hastagiris();
            hstgiris.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            laboratuvar lb = new laboratuvar();
            lb.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            kayıt kyt = new kayıt();    
            kyt.Show();

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            yöneticigiris admin = new yöneticigiris();
            admin.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            hastaKabul hstkabul = new hastaKabul();
            hstkabul.Show();
        }

        private void anasayfa_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            randevuAl yeni = new randevuAl();
            yeni.Show();
        }
        public static SqlDataAdapter da;
        public static DataTable dt;
        public static SqlDataReader dr;
        randevuGörüntüle randevu = new randevuGörüntüle();

        private void button6_Click(object sender, EventArgs e)
        {


            try
            {
                randevuGörüntüle randevu = new randevuGörüntüle();

                randevu.Show();

                baglan.Open();

                SqlCommand görüntüle = new SqlCommand("Select randevular.randevu_id,klinkler.klinik_adi,randevular.randevu_tarih,randevular.randevu_saat,hasta.hasta_tc,hasta.hasta_ad,hasta.hasta_soyad,doktorlar.doktor_adi_soyadi from " +
                    "randevular INNER JOIN hasta on randevular.randevu_hasta_id=hasta.hasta_id INNER JOIN klinkler ON randevular.randevu_klinik_id=klinkler.klinik_id INNER JOIN doktorlar ON randevular.randevu_doktor_id = doktorlar.doktor_id where hasta.hasta_id=@id", baglan);
                görüntüle.Parameters.AddWithValue("@id","9");
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

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                bekleyenHasta hasta = new bekleyenHasta();
                hasta.Show();
                baglan.Open();
                SqlCommand bekleyen_list = new SqlCommand("select bekleyenHasta.bekleyen_id,klinkler.klinik_adi,doktorlar.doktor_adi_soyadi,hasta.hasta_id from " +
                    "bekleyenHasta INNER JOIN klinkler on bekleyenHasta.bekleyen_klinik_id = klinkler.klinik_id  " +
                    "INNER JOIN doktorlar on bekleyenHasta.bekleyen_doktor_id = doktorlar.doktor_id " +
                    "INNER JOIN hasta on bekleyenHasta.bekleyen_hasta_id = hasta.hasta_id", baglan);
                bekleyen_list.Parameters.AddWithValue("@id","6");
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
    }
}
