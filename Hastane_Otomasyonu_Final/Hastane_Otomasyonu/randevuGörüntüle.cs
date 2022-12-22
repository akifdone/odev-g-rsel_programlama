using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hastane_Otomasyonu
{
    public partial class randevuGörüntüle : Form
    {
        public randevuGörüntüle()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection("Data Source=AKIF;Initial Catalog=HastaneOtomasyonuDb;Integrated Security=True");
        public static SqlDataAdapter da;
        public static DataTable dt;
        public static SqlDataReader dr;


        private void randevuGörüntüle_Load(object sender, EventArgs e)
        {
           

           
            

        }
    }
}
