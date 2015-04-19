using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string source = "server=(local) \\SQLEXPRESS;integrated security=SSPI;database=Student";
            SqlConnection con = new SqlConnection(source);//建立一个连接
            con.Open();//打开数据库
            //调用没有返回值的存储过程之记录的更新
            if (con.State == ConnectionState.Open)//ConnectionState为枚举值，描述数据源的连接状态为打开
                Console.WriteLine("数据库连接成功！");


            //SqlCommand com = new SqlCommand("studentupdate", con);//创建一条命令，调用命令将要执行在sql 2008中定义好的存储过程
            ////接着开始调用存储过程，因为该存储过程中有两个输入参数，所以需要构建两个参数，设置他们的值，然后添加到Parameters（参数集合）中
            //com.CommandType = CommandType.StoredProcedure;//com.CommandType：获取或设置一个值，该值指示如何解释 CommandText属性，CommandText属性：对数据源执行的 Transact-SQL 语句、表名或存储过程   CommandType枚举指定如何解释命令字符串
            //com.Parameters.AddWithValue("@id", 1);//表示向 SqlParameterCollection 的末尾添加值,SqlParameterCollection表示参数的集合，该语句还可以用com.Parameters.Add(new SqlParameter("@id","id"))代替
            //com.Parameters.AddWithValue("@name", "bob");
            //int x = com.ExecuteNonQuery();//调用该存储过程
            //Console.WriteLine("受影响的行数：{0}", x);


            //调用没有返回值的存储过程之记录的删除
            SqlCommand com2 = new SqlCommand("studentdelete", con);
            com2.CommandType = CommandType.StoredProcedure;
            SqlParameter sp = new SqlParameter("@id", SqlDbType.Int, 0, "id");
            com2.UpdatedRowSource = UpdateRowSource.None;//UpdateRowSource枚举：指定如何将查询命令结果应用到正在更新的行，none表示忽略任何返回的参数或行
            com2.Parameters.Add(sp);//将指定的 SqlParameter 对象添加到 SqlParameterCollection 中,参数还没有赋值，而com.Parameters.AddWithValue（）已经赋值
            sp.Value = 1;//或者用cmd.Parameters["@id"].value=1
            com2.ExecuteNonQuery();
            Console.WriteLine("删除成功！");
            //con.Close();


            //调用有返回值的存储过程之记录的插入
            //SqlCommand com3 = new SqlCommand("studentinsert", con);
            //com3.CommandType = CommandType.StoredProcedure;
            //com3.Parameters.Add(new SqlParameter("@name", "李四"));
            //com3.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 0, ParameterDirection.Output, false, 0, 0, "id", DataRowVersion.Default, 0));
            //com3.UpdatedRowSource = UpdateRowSource.OutputParameters;//UpdateRowSource枚举：指定如何将查询命令结果应用到正在更新的行,OutputParameters表示将输出参数映射到dataset中已经更改的行
            //com3.ExecuteNonQuery();
            //int x = (int)com3.Parameters["@id"].Value;
            //Console.WriteLine("输出参数(下一个id号)为：{0}", x);


            //调用有返回值得存储过程：返回一组记录
            //SqlCommand com4 = new SqlCommand("returnstudent", con);
            //com4.CommandType = CommandType.StoredProcedure;
            //com4.Parameters.Add(new SqlParameter("@id", 3));
            //com4.Parameters.Add(new SqlParameter("@rid", SqlDbType.Int,0, ParameterDirection.Output, false, 0, 0, "id", DataRowVersion.Default, 0));
            //com4.Parameters.Add("@rname", SqlDbType.Char, 20).Direction = ParameterDirection.Output;//
            //com4.ExecuteNonQuery();
            //int x = (int)com4.Parameters["@id"].Value;
            //string y = com4.Parameters["@rname"].Value.ToString().Trim();
            //Console.WriteLine("id:{0} name:{1}", x, y);



            //调用没有返回值得存储过程之查询
            SqlCommand com5 = new SqlCommand("selectstudent", con);
            com5.CommandType = CommandType.StoredProcedure;
            com5.Parameters.AddWithValue("@id", 5);
            SqlDataReader data = com5.ExecuteReader();
            while (data.Read())
            {
                Console.WriteLine("name:{0} id:{1}", data[0], data[1]);
            }
        }
    }
}
 