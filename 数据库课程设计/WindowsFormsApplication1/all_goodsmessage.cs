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
    public partial class all_goodsmessage : Form
    {
        public all_goodsmessage()
        {
            InitializeComponent();
        }
        string source = "server=(local) \\SQLEXPRESS;database=market;integrated security=true";
        //string source2 = "server=(local) \\SQLEXPRESS;database=users;integrated security=true";
        SqlConnection con;
        //SqlConnection con2;
        DataSet ds = new DataSet();
        //DataSet ds2 = new DataSet();
        SqlDataAdapter sda;
        private void all_goodsmessage_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            con = new SqlConnection(source);
            con.Open();
            string name = yonghuyanzhengjiemian.yonghuname;
            string select = "select * from goods";
            sda = new SqlDataAdapter(select, con);
            sda.Fill(ds, "allgoodsmessage");
            dataGridView1.DataSource = ds.Tables["allgoodsmessage"];
        }
    }
}
