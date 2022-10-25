using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KutuphaneOtomasyonu
{
    public partial class AnaEkran : Form
    {
        public AnaEkran()
        {
            InitializeComponent();
        }

        

        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KitapEklemeEkrani kitapEklemeEkrani = new KitapEklemeEkrani(this);
            kitapEklemeEkrani.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int secili = listBox1.SelectedIndex;
            var seciliad = listBox1.SelectedItem;


            DialogResult secenek = MessageBox.Show(seciliad + " Kitabını Kaldırmak İstediğinize Emin misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (secenek == DialogResult.Yes)
            {
                listBox1.Items.RemoveAt(secili);
            }
            else if (secenek == DialogResult.No)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {                      
           düzenle dzn = new düzenle(this);
           dzn.textBox1.Text = listBox1.SelectedItem.ToString();           
           dzn.Show();          

        }

      
    }
}
