using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;

namespace 自制计时器
{
    public partial class Form1 : Form
    {
        int inth, intm, ints;
        public Form1()
        {
            
            InitializeComponent();
            timer1.Enabled = true;//启动form的同时启动timer1组件，即获取系统时间
            label1.Text = "";//将提示框置空
            label2.Text = "";
        }
        /// <summary>
        /// 启动timer组件开始倒计时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime gettime = Convert.ToDateTime(DateTime.Now.ToString());//获取系统当前时间
            DateTime ontime = Convert.ToDateTime(textBox2.Text.Trim().ToString());//获取指定的时间
            TimeSpan sta=TimeSpan.FromHours(0);//初始化一个表示时间间隔的对象
            long dat = DateAndTime.DateDiff("s", gettime, ontime, FirstDayOfWeek.Sunday, FirstWeekOfYear.FirstFourDays);//获取时间差，固定方法
            if (dat > 0)//还未到达指定的时间
            {
                if (timer2.Enabled != true)//timer组件还未启动，即还未开始计时
                {
                    timer1.Enabled = true;//获取系统时间的组件开始启动
                    timer2.Enabled = true;//获取时间差的组件开始启动
                    label2.Text = "闹钟已启动！";
                    label1.Text = "剩余" + dat.ToString() + "秒";
                }
                else
                {
                    MessageBox.Show("闹钟已启动，请取消后再启动！");//避免重复启动
                }
            }
            else//指定时间已经过去时
            {
                long hour = 24 * 3600 + dat;//将指定时间设为下一天
                timer1.Enabled = true;
                timer2.Enabled = true;
                label2.Text = "闹钟已启动！";
                label1.Text = "剩余" + hour.ToString() + "秒";//同理上
            }
        }
        /// <summary>
        /// 获取时间差的组件的实现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer2_Tick(object sender, EventArgs e)
        {
            DateTime gettime = Convert.ToDateTime(DateTime.Now.ToString());
            DateTime ontime = Convert.ToDateTime(textBox2.Text.Trim().ToString());
            //TimeSpan sta=TimeSpan.FromHours(0);
            long dat = DateAndTime.DateDiff("s", gettime, ontime, FirstDayOfWeek.Sunday, FirstWeekOfYear.FirstFourDays);
            if (dat > 0)
            {
                label1.Text = "剩余" + dat.ToString() + "秒";
            }
            else
            {
                long hour = 24 * 3600 + dat;
                label1.Text = "剩余" + hour.ToString() + "秒";
            }
            if (dat == 0)
            {
                //Beep(200, 500);
                label2.Text = "时间到啦！";
                timer2.Enabled = false;//时间到则终止组件timer2
            }

        }
        /// <summary>
        /// 设置指定时间的小时值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            string h, m, s;
            if (numericUpDown1.Value == 24)//满24小时时
            {
                numericUpDown1.Value = 0;
                inth = Convert.ToInt32(numericUpDown1.Value);
                //以下代码为控制显示的格式
                if (inth < 10)
                {
                    h = "0" + inth.ToString() + ":";
                }
                else
                {
                    h = inth.ToString() + ":";
                }
                if (intm < 10)
                {
                    m = "0" + intm.ToString() + ":";
                }
                else
                {
                    m = intm.ToString() + ":";
                }
                if (ints < 10)
                {
                    s = "0" + ints.ToString();
                }
                else
                {
                    s = ints.ToString();
                }
                textBox2.Text = h + m + s;
            }
            else//不满24小时
            {
                inth = Convert.ToInt32(numericUpDown1.Value);
                if (inth < 10)
                {
                    h = "0" + inth.ToString() + ":";
                }
                else
                {
                    h = inth.ToString() + ":";
                }
                if (intm < 10)
                {
                    m = "0" + intm.ToString() + ":";
                }
                else
                {
                    m = intm.ToString() + ":";
                }
                if (ints < 10)
                {
                    s = "0" + ints.ToString();
                }
                else
                {
                    s = ints.ToString();
                }
                textBox2.Text = h + m + s;
            }
            
        }
        /// <summary>
        /// 设置指定时间的分钟值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        { 
            //以下代码同上
            string h, m, s;
            if (numericUpDown2.Value == 60)
            {
                numericUpDown2.Value = 0;
                numericUpDown1.Value = Convert.ToInt32(numericUpDown1.Value) + 1;//60分进位1小时
                inth = Convert.ToInt32(numericUpDown1.Value);
                intm = Convert.ToInt32(numericUpDown2.Value);
                if (inth < 10)
                {
                    h = "0" + inth.ToString() + ":";
                }
                else
                {
                    h = inth.ToString() + ":";
                }
                if (intm < 10)
                {
                    m = "0" + intm.ToString() + ":";
                }
                else
                {
                    m = intm.ToString() + ":";
                }
                if (ints < 10)
                {
                    s = "0" + ints.ToString();
                }
                else
                {
                    s = ints.ToString();
                }
                textBox2.Text = h + m + s;
            }
            else
            {
                intm = Convert.ToInt32(numericUpDown2.Value);
                if (inth < 10)
                {
                    h = "0" + inth.ToString() + ":";
                }
                else
                {
                    h = inth.ToString() + ":";
                }
                if (intm < 10)
                {
                    m = "0" + intm.ToString() + ":";
                }
                else
                {
                    m = intm.ToString() + ":";
                }
                if (ints < 10)
                {
                    s = "0" + ints.ToString();
                }
                else
                {
                    s = ints.ToString();
                }
                textBox2.Text = h + m + s;
            }

        }
        /// <summary>
        /// 设置指定时间的秒值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            string h, m, s;
            if (numericUpDown3.Value == 60)
            {
                numericUpDown3.Value = 0;
                numericUpDown2.Value = Convert.ToInt32(numericUpDown2.Value) + 1;
                ints = Convert.ToInt32(numericUpDown3.Value);
                intm = Convert.ToInt32(numericUpDown2.Value);
                if (inth < 10)
                {
                    h = "0" + inth.ToString() + ":";
                }
                else
                {
                    h = inth.ToString() + ":";
                }
                if (intm < 10)
                {
                    m = "0" + intm.ToString() + ":";
                }
                else
                {
                    m = intm.ToString() + ":";
                }
                if (ints < 10)
                {
                    s = "0" + ints.ToString();
                }
                else
                {
                    s = ints.ToString();
                }
                textBox2.Text = h + m + s;
            }
            else
            {
                ints = Convert.ToInt32(numericUpDown3.Value);
                if (inth < 10)
                {
                    h = "0" + inth.ToString() + ":";
                }
                else
                {
                    h = inth.ToString() + ":";
                }
                if (intm < 10)
                {
                    m = "0" + intm.ToString() + ":";
                }
                else
                {
                    m = intm.ToString() + ":";
                }
                if (ints < 10)
                {
                    s = "0" + ints.ToString();
                }
                else
                {
                    s = ints.ToString();
                }
                textBox2.Text = h + m + s;
            }

        }
        /// <summary>
        /// 功能为获取系统时间组件timer1的实现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime gettime = Convert.ToDateTime(DateTime.Now.ToString());
            textBox1.Text = Convert.ToString(gettime);//将系统时间显示在textbox1上
        }
        /// <summary>
        /// 取消闹钟按钮的实现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            timer2.Enabled = false;//终止功能为获取时间差的组件启动
            label2.Text = "闹钟已取消！";
            label1.Text = "";
        }

    }
}
