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

    public partial class Form1_c : Form
    {
        string username;
        string password;
        static string ipstring;
        IPEndPoint targetIP;
        TcpClient tcp_client = new TcpClient();
        NetworkStream stream;
        byte[] readbytes = new byte[1024];
        byte[] writebytes = new byte[1024];
        string data = null;

        public Form1_c()
        {
            InitializeComponent();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            //Clear buffers
            Array.Clear(readbytes, 0, readbytes.Length);
            Array.Clear(writebytes, 0, writebytes.Length);
            try
            {
                // Read all bytes from client 
                while (stream.Read(readbytes, 0, readbytes.Length) > 0)
                {
                    // Translate data bytes to a ASCII string and print to messageLog
                    data = Encoding.ASCII.GetString(readbytes);
                    messageLog.Text += (data);
                }
            }
            catch (System.IO.IOException)
            {
                //messageLog.Text += "TIMEOUT!\r\n";
            }
            //Send current message
            if (inputText.Text.Length > 0)
            {
                messageLog.Text += username + ": " + inputText.Text + "\r\n";
                writebytes = System.Text.Encoding.ASCII.GetBytes(username + ": " + inputText.Text + "\r\n");
                stream.Write(writebytes, 0, writebytes.Length);
                inputText.Text = "";
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            username = inputUsername.Text;
            password = inputPassword.Text;
            ipstring = inputIP.Text;
            targetIP = new IPEndPoint(IPAddress.Parse(ipstring), 8081);
            tcp_client.Connect(targetIP);
            stream = tcp_client.GetStream();
            tcp_client.ReceiveTimeout = 100;
            //Feedback after connection
            if (tcp_client.Connected)
            {
                messageLog.Text += "Successful Connection!\r\n";
            }
            else
            {
                messageLog.Text += "Connection Unsuccessful...\r\n";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
