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
    public partial class bekleyenHasta : Form
    {
        public bekleyenHasta()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=AKIF;Initial Catalog=HastaneOtomasyonuDb;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            randevuMuayne muayene = new randevuMuayne();
            muayene.Show();
            string deger = dataGridView1.CurrentRow.Cells["hasta_id"].Value.ToString();
            textBox1.Text = deger;
            try
            {
                if(textBox1.Text != "")
                {
                    baglanti.Open();
                    SqlCommand sorgu = new SqlCommand("select * from hasta where hasta_id=@id",baglanti);
                    sorgu.Parameters.AddWithValue("@id", textBox1.Text);
                    SqlDataReader oku = sorgu.ExecuteReader();
                    
                    if (oku.Read())
                    {
                        
                        muayene.maskedTextBox1.Text = oku[1].ToString();
                        muayene.textBox1.Text = oku[2].ToString();
                        muayene.textBox2.Text = oku[3].ToString();
                        muayene.textBox6.Text = oku[4].ToString();
                        muayene.textBox7.Text = oku[5].ToString();
                        muayene.textBox8.Text = oku[6].ToString();
                        muayene.maskedTextBox3.Text = oku[7].ToString();
                        muayene.textBox3.Text = oku[8].ToString();
                        muayene.textBox4.Text = oku[9].ToString();
                        
                       
                    }
                   
                }
                else
                {
                    MessageBox.Show("Lütfen Hasta İD Giriniz");
                }
                baglanti.Close();
            }
            catch (Exception hata)
            {

                MessageBox.Show("hata" + "" + hata);
            }
        }
    }
}
