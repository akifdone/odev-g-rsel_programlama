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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hastane_Otomasyonu
{
    public partial class kayıt : Form
    {
        public kayıt()
        {
            InitializeComponent();
        }

        static string constring = "Data Source=AKIF;Initial Catalog=HastaneOtomasyonuDb;Integrated Security=True";
        SqlConnection connect = new SqlConnection(constring);
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(connect.State== ConnectionState.Closed)
                connect.Open();
                string kayit = "insert into hasta (hasta_tc,hasta_ad,hasta_soyad,hasta_cinsiyeti,hasta_kan,hasta_dogumYeri,hasta_dogumTarihi,hasta_babaAdi,hasta_anaAdi,hasta_tel,hasta_posta,hasta_parola,hasta_adres) " +
                "values(@hasta_tc,@hasta_ad,@hasta_soyad,@hasta_cinsiyeti,@hasta_kan,@hasta_dogumYeri,@hasta_dogumTarihi,@hasta_babaAdi,@hasta_anaAdi,@hasta_tel,@hasta_posta,@hasta_parola, @hasta_adres)";
                SqlCommand komut = new SqlCommand(kayit, connect);
                komut.Parameters.AddWithValue("@hasta_tc",textTc.Text);
                komut.Parameters.AddWithValue("@hasta_ad",texthastaAdi.Text);
                komut.Parameters.AddWithValue("@hasta_soyad",texthastaSoyadi.Text);
                komut.Parameters.AddWithValue("@hasta_cinsiyeti",textCinsiyeti.Text);
                komut.Parameters.AddWithValue("@hasta_kan",comboboxKan.Text);
                komut.Parameters.AddWithValue("@hasta_dogumYeri", comboboxDogumyeri.Text);
                komut.Parameters.AddWithValue("@hasta_dogumTarihi", hastaDogumTrh.Text);
                komut.Parameters.AddWithValue("@hasta_babaAdi",texthstBaba.Text);
                komut.Parameters.AddWithValue("@hasta_anaAdi",texthstAnne.Text);
                komut.Parameters.AddWithValue("@hasta_tel",textTel.Text);
                komut.Parameters.AddWithValue("@hasta_posta",textPosta.Text);
                komut.Parameters.AddWithValue("@hasta_parola",textPass.Text);
                komut.Parameters.AddWithValue("@hasta_adres",textAdress.Text);

                komut.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show("kayıt eklendi");

            }
            catch (Exception hata)
            {

                MessageBox.Show("hatameydan geldi"+""+hata.Message);


                
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(texthastaAdi.Text != " " && texthastaSoyadi.Text !=" "  && textPosta.Text != " " )
            {
                button1.Enabled = false;
                button3.Enabled = true;
            }

          

            try
            {
                if (textTc.Text != " ")
                {
                    if (connect.State == ConnectionState.Open)
                        connect.Close();

                    connect.Open();
                    SqlCommand sorgulama = new SqlCommand("select * from hasta where hasta_tc=@tc", connect);
                    sorgulama.Parameters.AddWithValue("@tc", textTc.Text);
                    SqlDataReader oku = sorgulama.ExecuteReader();
                    if (oku.Read())
                    {

                        texthastaAdi.Text = oku[2].ToString();
                        texthastaSoyadi.Text = oku[3].ToString();
                        textCinsiyeti.Text = oku[4].ToString();
                        comboboxKan.Text = oku[5].ToString();
                        comboboxDogumyeri.Text = oku[6].ToString();
                        hastaDogumTrh.Text = oku[7].ToString();
                        texthstBaba.Text = oku[8].ToString();
                        texthstAnne.Text = oku[9].ToString();
                        textTel.Text = oku[10].ToString();
                        textPosta.Text = oku[11].ToString();
                        textAdress.Text = oku[13].ToString();
                        MessageBox.Show("Bu kritere uyan bir hasta bulundu.");
                        


                    }
                    else
                        MessageBox.Show("Bu kriterde bir hasta bulunamadı. Lütfen kayıt yapınız.");
                    connect.Close();
                }
                else
                    MessageBox.Show("Önce Hasta TC'si giriniz.");

            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata!! " + " " + hata);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            
                if (textPass.Text != "" && textPass.Text.Length > 4)
                {
                    if (connect.State == ConnectionState.Closed)
                        connect.Open();
                    string kayit = "insert into hasta (hasta_parola) values(@hasta_parola)";
                    SqlCommand komut = new SqlCommand(kayit, connect);
                    komut.Parameters.AddWithValue("@hasta_parola", textPass.Text);
                    MessageBox.Show("Şifreniz Oluşturuldu");

                }
                else
                {

                    MessageBox.Show("Lütfen Geçerli Bir Değer Girniz");
                }



        }
    }
}
