using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    public class UesrInfo
    {
        string username, password, ipaddress, port;
        public string UserName
        {
            get { return username; }
            set { username = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string IpAddress
        {
            get { return ipaddress; }
            set { ipaddress = value; }
        }
        public string Port
        {
            get { return port; }
            set { port = value; }
        }
    }
}
