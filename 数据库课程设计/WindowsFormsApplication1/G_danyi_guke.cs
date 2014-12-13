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

namespace WindowsFormsApplication1
{
    public partial class G_danyi_guke :Form
    {
        public G_danyi_guke()
        {
            InitializeComponent();
        }
        public static string name;
        private void button1_Click(object sender, EventArgs e)
        {
            //this.Close();
            name = textBox1.Text.Trim();
            G_xianshi_dayiguke f = new G_xianshi_dayiguke();
            f.ShowDialog();

            //管理员界面 f = new 管理员界面();
            //f.ShowDialog();
            
            
            //sc.ExecuteNonQuery();
        }

        private void G_danyi_guke_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
