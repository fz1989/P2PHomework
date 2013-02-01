using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;
namespace Client
{
    class GetFile
    {
        string ipaddress, filename, port, filepath;
        public string IpAddress
        {
            set { ipaddress = value; }
            get { return ipaddress; }
        }
        public string FileName
        {
            set { filename = value; }
            get { return filename; }
        }
        public string Port 
        {
            set { port = value; }
            get { return port; }
        }
        public string FilePath
        {
            set { filepath = value; }
            get { return filepath; }
        }
        public bool DownloadFile()
        {
            Socket connectServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(ipaddress), int.Parse(port));
            connectServer.Connect(iep);
            Byte[] sendHeader = Encoding.GetEncoding("UTF-8").GetBytes(filepath);
            connectServer.Send(sendHeader);
            Byte[] buffer = new Byte[10240];
            int num = connectServer.Receive(buffer);
            long needReceive = long.Parse(Encoding.GetEncoding("UTF-8").GetString(buffer, 0, num));
            FileInfo file = new FileInfo(filename);
            FileStream writer = file.Open(file.Exists ? FileMode.Append : FileMode.CreateNew, FileAccess.Write, FileShare.None);
            long receive = writer.Length;
            int received = 0;
            while (receive < needReceive)
            {
                if ((received = connectServer.Receive(buffer)) == 0) break;
                writer.Write(buffer, 0, received);
                writer.Flush();
                receive += (long)received;

                Thread.Sleep(200);
            }
            writer.Close();
            return true;
        }
    }
}
