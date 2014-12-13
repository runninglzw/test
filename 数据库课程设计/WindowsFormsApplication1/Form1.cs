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
    public partial class zhujiemian : Form
    {
        public zhujiemian()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
        }

        private void yonghudenglu_Click(object sender, EventArgs e)
        {
            yonghuyanzhengjiemian f = new yonghuyanzhengjiemian();
            f.ShowDialog();
        }

        private void zhujiemian_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("是否关闭页面", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                e.Cancel = false;//指示不应该取消事件，继续关闭
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;//指示取消事件，停止关闭
            }
        }

        private void guanliyuandenglu_Click(object sender, EventArgs e)
        {
            guanliyuandenglu f = new guanliyuandenglu();
            f.ShowDialog();
        }
    }
}
