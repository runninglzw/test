using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using System.Threading;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        
        {
            string jsonText = @"[{'Languages':['C#','Java'],'Name':'李志伟','Sex':true},{'Languages':['C#','C++'],'Name':'Coder2','Sex':false},{'Languages':['C#','C++','C','Java'],'Name':'Coder3','Sex':true}]";
            
            //使用索引解析json字符串
            JToken jo = (JToken)((JArray)JsonConvert.DeserializeObject(jsonText))[0];//将字符串反序列化为JArray类，在强制转化为JObject,也可转化为JToken，JArrray是是一个JObject或JToken的数组
            Console.WriteLine(jo["Languages"][0]);
            



            //使用JArray，JObject，JToken解析
            JArray ja = (JArray)JsonConvert.DeserializeObject(jsonText); 
            foreach (JToken jt in ja)
            {
                JArray jarray=(JArray)jt["Languages"];
                foreach (JToken jtoken in jarray)
                {
                    Console.WriteLine(jtoken + "");
                }
                Console.WriteLine("name:" + jt["Name"] + "\t" + "Sex:" + jt["Sex"]);
            }












            //JsonReader reader = new JsonTextReader(new StringReader(jsonText));  //很少用JsonReader
            //while (reader.Read())
            //{
            //    Thread.Sleep(1000);
            //    Console.WriteLine(reader.TokenType + "\t\t" + reader.ValueType + "\t\t" + reader.Value);
            //}
        }
    }
}
