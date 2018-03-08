using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace SecretChatter
{

    public partial class Form1 : Form
    {
        string username;
        string password;
        static string ipstring;
        IPEndPoint targetIP;
        TcpClient tcp_client = new TcpClient();
        TcpListener listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 8881);

        public Form1()
        {
            listener.Start();
            InitializeComponent();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            username = inputUsername.Text;
            password = inputPassword.Text;
            ipstring = inputIP.Text;
            targetIP = new IPEndPoint(IPAddress.Parse(ipstring), 8881);
            tcp_client.Connect(targetIP);
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            messageLog.Text += username + ": " + inputText.Text + "\r\n";
            inputText.Text = "";

                        
        }
    }
}
