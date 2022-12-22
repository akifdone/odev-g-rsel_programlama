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
    public partial class randevuAl : Form
    {
        public randevuAl()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection("Data Source=AKIF;Initial Catalog=HastaneOtomasyonuDb;Integrated Security=True");


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                baglan.Open();
                if (comboBox1.SelectedIndex != 0 && comboBox2.SelectedIndex != 0)
                {
                    SqlCommand randevuekle = new SqlCommand("insert into randevular(randevu_hasta_id,randevu_tarih,randevu_saat,randevu_klinik_id,randevu_doktor_id)  values(@id,@tarih,@saat,@kid,@did)", baglan);
                    randevuekle.Parameters.AddWithValue("@id", textBox1.Text.ToString());
                    randevuekle.Parameters.AddWithValue("@tarih", dateTimePicker1.Value.ToShortDateString());
                    randevuekle.Parameters.AddWithValue("@saat", "9");
                    randevuekle.Parameters.AddWithValue("@kid", comboBox2.SelectedValue.ToString());
                    randevuekle.Parameters.AddWithValue("@did", comboBox1.SelectedValue.ToString());

                    randevuekle.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show(" randevu alınmıştır");
                    comboBox1.SelectedIndex = comboBox2.SelectedIndex = 0;

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Hata!! " + " "+ ex);
            }
        }

        private void randevuAl_Load(object sender, EventArgs e)
        {
           
        }

        private void randevuAl_Load_1(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'hastaneOtomasyonuDbDataSet.doktorlar' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.doktorlarTableAdapter.Fill(this.hastaneOtomasyonuDbDataSet.doktorlar);
            // TODO: Bu kod satırı 'hastaneOtomasyonuDbDataSet.klinkler' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.klinklerTableAdapter.Fill(this.hastaneOtomasyonuDbDataSet.klinkler);

        }
    }
}
