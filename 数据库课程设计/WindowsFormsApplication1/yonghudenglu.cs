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
    public partial class yonghuyanzhengjiemian : Form
    {
        public yonghuyanzhengjiemian()
        {            
            InitializeComponent();
        }
        public static string yonghuid;
        public static string yonghumima;
        public static string yonghuname;
        private void yonghuyanzheng_Load(object sender, EventArgs e)
        {

        }

        private void denglubutton_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(Convert.ToString(yonghuming_textbox.Text == null));
            string source = "server=(local) \\SQLEXPRESS;database=users;integrated security=SSPI";
            SqlConnection con = new SqlConnection(source);
            con.Open();//打开数据库
            if (con.State == ConnectionState.Open)
                MessageBox.Show("数据库连接成功！");
            string select = "select * from yonghu";
            SqlDataAdapter sda = new SqlDataAdapter(select, con);
            DataSet ds = new DataSet();
            sda.Fill(ds, "yonghu");
            int flag = 0;//设置一个标记，判断用户是否登录成功
            foreach (DataRow x in ds.Tables["yonghu"].Rows)
            {
                if (yonghuming_textbox.Text == x["id"].ToString().Trim() && yonghumina_textbox.Text == x["mima"].ToString().Trim())
                {
                    yonghuid = yonghuming_textbox.Text;
                    yonghumima = yonghumina_textbox.Text;
                    yonghuname = x["name"].ToString().Trim();
                    flag = 1;
                    //MessageBox.Show(x["name"].ToString());
                    //如果yonghu数据库中的name不为空，则进入用户界面
                    if (x["name"].ToString().Trim() != String.Empty)//此处用String.Empty而不用null是因为数据库中为赋值的行为“”而不是null
                    {
                        //if()
                        yuhujiemian f3 = new yuhujiemian();
                        f3.ShowDialog();

                    }
                        //否则进入绑定界面
                    else
                    {
                        yonghubangding yhbd = new yonghubangding();
                        yhbd.ShowDialog();
                    }

                }
            }
            if (flag == 0)//如果没有登录成功，则显示
            {
                MessageBox.Show("用户名或密码错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void zhuce_button_Click(object sender, EventArgs e)
        {
            zhuce_jiemian f=new zhuce_jiemian();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
