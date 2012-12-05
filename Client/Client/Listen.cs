using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;
namespace Client
{
    class Listen
    {
        UesrInfo userInfo;
        Listen()
        {
            userInfo = new UesrInfo();
        }
        public void setUserInfo(UesrInfo inUser)
        {
            userInfo = inUser;
        }
        public void sendFile(object input)
        {
            Socket connectSocket = input as Socket;
            Byte[] byteMessage = new Byte[256];
            connectSocket.Receive(byteMessage);
            string filePath = Encoding.GetEncoding("UTF-8").GetString (byteMessage);
            FileStream reader = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None);
            Byte[] Buffer = new Byte[10240];
            int read, sent = 0;
            bool flag = true;
            FileInfo newFileInfo = new FileInfo(filePath);
            long filesize = newFileInfo.Length;
            connectSocket.Send(Encoding.GetEncoding("UTF-8").GetBytes(filesize.ToString()));
            while ((read = reader.Read(Buffer,0,10240)) != 0) {
                sent = 0;
                flag = true;
                while ((sent += connectSocket.Send(Buffer, sent, read, SocketFlags.None)) < read)
                {
                    flag = false;
                }
                Thread.Sleep(200);
                if (flag)
                {

                    Thread.Sleep(200);

                }
                reader.Close();
            }
        }
        public void BeginListen()
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(userInfo.IpAddress), int.Parse(userInfo.Port));
            Socket ListenSocket =  new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ListenSocket.Bind(iep);
            ListenSocket.Listen(255);
            while (true)
            {
                Socket connectSocket = ListenSocket.Accept();
                Thread newConnectThread = new Thread(sendFile);
                newConnectThread.Start(connectSocket);
            }
        }
    }
}
