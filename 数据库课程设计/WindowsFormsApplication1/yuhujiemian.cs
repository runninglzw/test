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
    public partial class yuhujiemian : Form
    {
        public yuhujiemian()
        {
            InitializeComponent();
        }
        private void yuhujiemian_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("是否退出", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                e.Cancel = false;//指示不应该取消事件，继续关闭
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;//指示取消事件，停止关闭
            }
        }

        private void 个人信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childrenForm in this.MdiChildren)
            {
                //检测是不是当前子窗体名称 
                if (childrenForm.Name == "gerenxinxi")
                {
                    //是的话就是把他显示 
                    childrenForm.Visible = true;
                    //并激活该窗体 
                    childrenForm.Activate();
                    //childrenForm.WindowState = FormWindowState.Maximized;
                    return;
                }
            }
            gerenxinxi grxx = new gerenxinxi();
            grxx.MdiParent = this;
            grxx.Show();

        }

        private void 订单信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childrenForm in this.MdiChildren)
            {
                //检测是不是当前子窗体名称 
                if (childrenForm.Name == "dingdanxinxi")
                {
                    //是的话就是把他显示 
                    childrenForm.Visible = true;
                    //并激活该窗体 
                    childrenForm.Activate();
                    //childrenForm.WindowState = FormWindowState.Maximized;
                    return;
                }
            }
            dingdanxinxi ddxx = new dingdanxinxi();
            ddxx.MdiParent = this;
            ddxx.Show();
        }

        private void 所有商品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childrenForm in this.MdiChildren)
            {
                //检测是不是当前子窗体名称 
                if (childrenForm.Name == "all_goodsmessage")
                {
                    //是的话就是把他显示 
                    childrenForm.Visible = true;
                    //并激活该窗体 
                    childrenForm.Activate();
                    //childrenForm.WindowState = FormWindowState.Maximized;
                    return;
                }
            }
            all_goodsmessage agm = new all_goodsmessage();
            agm.MdiParent = this;
            agm.Show();
        }

        private void 水平排列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);//水平排列子窗体
        }

        private void 垂直排列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);//垂直排列子窗体
        }

        private void 层叠排列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);// 层叠排列子窗体
        }

        private void yuhujiemian_Load(object sender, EventArgs e)
        {

        }

        private void 购买商品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int all = 0, dingdan = 0;
            foreach (Form childrenForm in this.MdiChildren)
            {
                //检测是不是当前子窗体名称 
                if (childrenForm.Name == "all_goodsmessage")
                {
                    all = 1;
                    //是的话就是把他显示 
                    childrenForm.Visible = true;
                    //并激活该窗体 
                    childrenForm.Activate();
                    //childrenForm.WindowState = FormWindowState.Maximized;
                    break;
                }
            }
            foreach (Form childrenForm in this.MdiChildren)
            {
                //检测是不是当前子窗体名称 
                if (childrenForm.Name == "chuangjiandingdan")
                {
                    dingdan = 1;
                    //是的话就是把他显示 
                    childrenForm.Visible = true;
                    //并激活该窗体 
                    childrenForm.Activate();
                    //childrenForm.WindowState = FormWindowState.Maximized;
                    break;
                }
            }
            if (all == 0)
            {
                all_goodsmessage agm = new all_goodsmessage();
                agm.MdiParent = this;
                agm.Show();
            }
            if (dingdan == 0)
            {
                chuangjiandingdan cjdd = new chuangjiandingdan();
                cjdd.MdiParent = this;
                cjdd.Show();
            }
            LayoutMdi(MdiLayout.TileHorizontal);//水平排列子窗体
        }

        private void 修改个人信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childrenForm in this.MdiChildren)
            {
                //检测是不是当前子窗体名称 
                if (childrenForm.Name == "updategerenxinxi")
                {
                    //是的话就是把他显示 
                    childrenForm.Visible = true;
                    //并激活该窗体 
                    childrenForm.Activate();
                    //childrenForm.WindowState = FormWindowState.Maximized;
                    return;
                }
            }
            updategerenxinxi upgrxx = new updategerenxinxi();
            upgrxx.MdiParent = this;
            upgrxx.Show();
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*yuhujiemian yhjm = new yuhujiemian();
            foreach (Form childrenForm in yhjm.MdiChildren)
            {
                //检测是不是当前子窗体名称 
                if (childrenForm.Name == "yonghuxiugaimima")
                {
                    //是的话就是把他显示 
                    childrenForm.Visible = true;
                    //并激活该窗体 
                    childrenForm.Activate();
                    //childrenForm.WindowState = FormWindowState.Maximized;
                    return;
                }
            }*/
            yonghuxiugaimima yhxgmm = new yonghuxiugaimima();
            // yhxgmm.MdiParent = yhjm;
            yhxgmm.ShowDialog();
        }

        private void 商品信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 单一商品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childrenForm in this.MdiChildren)
            {
                //检测是不是当前子窗体名称 
                if (childrenForm.Name == "G_danyi_shangpin")
                {
                    //是的话就是把他显示 
                    childrenForm.Visible = true;
                    //并激活该窗体 
                    childrenForm.Activate();
                    //childrenForm.WindowState = FormWindowState.Maximized;
                    return;
                }
            }
            G_danyi_shangpin yds = new G_danyi_shangpin();
            yds.MdiParent = this;
            yds.Show();
        }

        private void 模糊查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childrenForm in this.MdiChildren)
            {
                //检测是不是当前子窗体名称 
                if (childrenForm.Name == "tiaojianchaxun")
                {
                    //是的话就是把他显示 
                    childrenForm.Visible = true;
                    //并激活该窗体 
                    childrenForm.Activate();
                    //childrenForm.WindowState = FormWindowState.Maximized;
                    return;
                }
            }
            tiaojianchaxun tjcx = new tiaojianchaxun();
            tjcx.MdiParent = this;
            tjcx.Show();
        }

        private void 模糊查询ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (Form childrenForm in this.MdiChildren)
            {
                //检测是不是当前子窗体名称 
                if (childrenForm.Name == "mohuchaxun")
                {
                    //是的话就是把他显示 
                    childrenForm.Visible = true;
                    //并激活该窗体 
                    childrenForm.Activate();
                    //childrenForm.WindowState = FormWindowState.Maximized;
                    return;
                }
            }
            mohuchaxun mhcx = new mohuchaxun();
            mhcx.MdiParent = this;
            mhcx.Show();
        }
    }
}
