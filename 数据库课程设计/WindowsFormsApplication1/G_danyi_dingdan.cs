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
    public partial class G_danyi_dingdan : Form
    {
        public static string name;
        public G_danyi_dingdan()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            name = textBox1.Text.Trim();
            G_xianshi_danyidingdan gxd = new G_xianshi_danyidingdan();
            gxd.ShowDialog();
        }
    }
}
