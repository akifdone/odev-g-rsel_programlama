using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VizeFinal_Hesaplama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            double vize, final, ortalama;

           
                vize = Convert.ToDouble(numericUpDown1.Value);
                final = Convert.ToDouble(numericUpDown2.Value);
                ortalama = vize * 0.4 + final * 0.6;
                listBox1.Items.Clear();
                listBox1.Items.Add(ortalama);

            if(ortalama<50 || final<50)
            {
                listBox2.Items.Clear();
                listBox2.Items.Add("KALDIN");
                listBox2.BackColor = Color.Red;
                
            }

            else
            {
                listBox2.Items.Clear();
                listBox2.Items.Add("GEÇTİN");
                listBox2.BackColor = Color.Green;
            }

            if(ortalama<=100 && ortalama >=90)
            {
                listBox3.Items.Clear();
                listBox3.Items.Add("AA");
                listBox3.BackColor =Color.GreenYellow;
            } 
            else if (ortalama <90 && ortalama>=80)
            {
                listBox3.Items.Clear();
                listBox3.Items.Add("BA");
                listBox3.BackColor = Color.GreenYellow;
            }
            else if (ortalama < 80 && ortalama >= 70)
            {
                listBox3.Items.Clear();
                listBox3.Items.Add("BB");
                listBox3.BackColor = Color.GreenYellow;
            }
            else if (ortalama < 70 && ortalama >= 60)
            {
                listBox3.Items.Clear();
                listBox3.Items.Add("CB");
                listBox3.BackColor = Color.GreenYellow;
            }
            else if (ortalama < 60 && ortalama >= 50)
            {
                listBox3.Items.Clear();
                listBox3.Items.Add("CC");
                listBox3.BackColor = Color.GreenYellow;
            }
            else if (ortalama < 50 && ortalama >= 0)
            {
                listBox3.Items.Clear();
                listBox3.Items.Add("FF");
                listBox3.BackColor = Color.IndianRed;
            }
           



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
