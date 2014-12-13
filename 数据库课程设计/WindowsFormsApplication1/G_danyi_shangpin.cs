using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class G_danyi_shangpin : Form
    {
        public static string name;
        public G_danyi_shangpin()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            name = textBox1.Text;
            G_xianshi_danyishangpin gxd = new G_xianshi_danyishangpin();
            gxd.ShowDialog();
        }
    }
}
