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
    public partial class hastaPaneli : Form
    {
        public hastaPaneli()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection("Data Source=AKIF;Initial Catalog=HastaneOtomasyonuDb;Integrated Security=True");

        private void button3_Click(object sender, EventArgs e)
        {
            randevuAl randevu = new randevuAl();
            randevu.textBox1.Text = label2.Text;
            randevu.Show();
            
           

        }

        private void hastaPaneli_Load(object sender, EventArgs e)
        {
       
        }
       
        public static SqlDataAdapter da;
        public static DataTable dt;
        public static SqlDataReader dr;
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                randevuGörüntüle randevu = new randevuGörüntüle();

                randevu.Show();

                baglan.Open();

                SqlCommand görüntüle = new SqlCommand("Select randevular.randevu_id,klinkler.klinik_adi,randevular.randevu_tarih,randevular.randevu_saat,hasta.hasta_tc,hasta.hasta_ad,hasta.hasta_soyad,doktorlar.doktor_adi_soyadi from " +
                    "randevular INNER JOIN hasta on randevular.randevu_hasta_id=hasta.hasta_id INNER JOIN klinkler ON randevular.randevu_klinik_id=klinkler.klinik_id INNER JOIN doktorlar ON randevular.randevu_doktor_id = doktorlar.doktor_id where hasta.hasta_id=@id", baglan);
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


    }
}
