using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.Win32;

namespace Service
{
    class xinxi
    {
        static public string getjincheng()
        {
           
            string result="进程：\n";
            Process[] processes = Process.GetProcesses();
            for (int i = 0; i < processes.Length; i++)
            {
                //我是要找到我需要的YZT.exe的进程,可以根据ProcessName属性判断
                //if (processes[i].ProcessName.Equals("YZT"))
                //{
                //    //立即停止关联的进程,建议不要用Close()方法
                //    processes[i].Kill();
                //}
                result += string.Format("进程"+ i + 1+":"+processes[i].ProcessName+"\n");
            }
            return result;
        }
        static public string getzhucebiao()
        {
            string result = "注册表：\n";
            //存储本地计算机的配置信息
            RegistryKey rk = Registry.LocalMachine;
            String[] names = rk.GetSubKeyNames();
            for (int i = 0; i < names.Length; i++)
            {
                result += string.Format(names[i] +"\n");
            }
            return result;
        }
        static public string getqidongxiang()
        {
            string result = "启动项:\n";
            RegistryKey pRegKey = null;
            pRegKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
            foreach (string ValueName in pRegKey.GetValueNames())
                result +=  ValueName+ "\n" ;
                //listBox1.Items.Add(string.Format("{0, -10} : {1}", regValueName, pRegKey.GetValue(regValueName)));
            return result;
        }
        static public String getliulanqi()
        {
            string result = "默认浏览器:";
            RegistryKey key = Registry.ClassesRoot.OpenSubKey("http\\shell\\open\\command", false);
            String path = key.GetValue("").ToString();
            if (path.Contains("\""))
            {
                path = path.TrimStart('"');
                path = path.Substring(0, path.IndexOf('"'));
            }
            int start = path.LastIndexOf('\\');
            //浏览器的名称
            string name = path.Substring(start + 1);
            //去掉后缀
            name = name.Substring(0, name.IndexOf('.'));
            result += string.Format(name+"\n" + "路径:" + path + "\n");
            key.Close();
            return result;
        }
        public static String getie()
        {
            return System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "Internet Explorer\\iexplore.exe");
        } 
        //删除启动项
        public static bool DeleteRegister(string name)
        {
            string ShortFileName =name;           //获得应用程序名  

            try
            {
                RegistryKey Reg;
                Reg = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (Reg == null)
                {
                    Reg = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run");
                }
                Reg.DeleteValue(ShortFileName, false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;
        }
        //添加启动项
        public static void SetRegistryApp(string name,string path)
        {
            try
            {
                Microsoft.Win32.RegistryKey Reg;
                string ShortFileName = name;
                Reg = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (Reg == null)
                {
                    Reg = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run");
                }
                Reg.SetValue(ShortFileName, path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        } 
    }
}
