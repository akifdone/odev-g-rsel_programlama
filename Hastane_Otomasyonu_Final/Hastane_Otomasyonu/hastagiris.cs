using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Reflection.Emit;
using System.Runtime.Remoting.Contexts;

namespace Hastane_Otomasyonu
{
    public partial class hastagiris : Form
    {
    
        public hastagiris()
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
                    SqlCommand cmd = new SqlCommand("Select * from  hasta where  hasta_posta = @posta AND hasta_parola = @pass", baglan);
                    cmd.Parameters.AddWithValue("@posta", textBox1.Text);
                    cmd.Parameters.AddWithValue("@pass", textBox2.Text);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {


                        MessageBox.Show("tebrikler giriş yaptınız");
                        hastaPaneli hastapanel = new hastaPaneli();
                        hastapanel.Show();
                        hastapanel.label4.Text = textBox1.Text.ToString();
                        hastapanel.label2.Text = dr["hasta_id"].ToString();
                        hastapanel.label11.Text = dr["hasta_ad"].ToString();
                        hastapanel.label12.Text = dr["hasta_soyad"].ToString();
                        hastapanel.label13.Text = dr["hasta_tc"].ToString();
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
