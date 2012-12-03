using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;

namespace Client
{
    class PostData
    {
        string inData;
        static string url = "http://219.245.98.140/index.php";
        public string InData
        {
            get { return inData; }
            set { inData = value; }
        }
        public string postPackge()
        {
            Encoding encoding = Encoding.GetEncoding("UTF-8");
            Stream outstream = null;
            Stream instream = null;
            StreamReader sr = null;
            HttpWebRequest request = null;
            HttpWebResponse response = null;

            // 准备请求,设置参数
            request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            byte[] data = encoding.GetBytes(inData);
            request.ContentLength = data.Length;
            //            Console.WriteLine(url + " " + inData);
            outstream = request.GetRequestStream();
            outstream.Write(data, 0, data.Length);
            outstream.Flush();
            outstream.Close();

            //发送请求并获取相应回应数据
            response = request.GetResponse() as HttpWebResponse;

            //直到request.GetResponse()程序才开始向目标网页发送Post请求

            instream = response.GetResponseStream();
            sr = new StreamReader(instream, encoding);
            //返回结果网页(html)代码

            string content = sr.ReadToEnd();
            string ret = "";
            for (int i = 2; i < content.Length; i++)
            {
                ret += content[i];
            }
            return ret;
        }
    }
}
