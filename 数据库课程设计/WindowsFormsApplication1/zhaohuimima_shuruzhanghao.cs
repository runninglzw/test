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
    public partial class zhaohuimima_shuruzhanghao : Form
    {
        public zhaohuimima_shuruzhanghao()
        {
            InitializeComponent();
        }
        public static string id;
        private void button1_Click(object sender, EventArgs e)
        {
            id = textBox1.Text;
            zhaohuimima zhmm = new zhaohuimima(textBox1.Text);
            zhmm.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
