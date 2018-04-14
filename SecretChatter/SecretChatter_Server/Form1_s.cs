using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace SecretChatter_Server
{
    public partial class Form1_s : Form
    {
        string username;
        string password;
        const int port = 8081;
        byte[] writebytes = new byte[1024];
        byte[] readbytes = new byte[1024];
        TcpListener server = new TcpListener(IPAddress.Any, port);
        string data = null;
        NetworkStream stream;
        TcpClient tcp_client;

        public Form1_s()
        {
            InitializeComponent();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
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
            this.waitConnect.RunWorkerAsync();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            server.Start();
        }


        private void waitConnect_DoWork(object sender, DoWorkEventArgs e)
        {
            username = inputUsername.Text;
            password = inputPassword.Text;
            tcp_client = server.AcceptTcpClient();
            stream = tcp_client.GetStream();
            //error if tcp_client not connected:
            if (!tcp_client.Connected)
            {
                //ERROR
            }

        }

        private void waitConnect_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            messageLog.Text += "Successful Connection!\r\n";
            this.msgListen.RunWorkerAsync();
        }

        private void msgListen_DoWork(object sender, DoWorkEventArgs e)
        {
            while (stream.Read(readbytes, 0, readbytes.Length) > 0)
            {
                // Report progress
                this.msgListen.ReportProgress(1);

            }
        }

        private void msgListen_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Translate data bytes to a ASCII string and print to messageLog

            data = Encoding.ASCII.GetString(readbytes);
            messageLog.Text += (data);
            Array.Clear(readbytes, 0, readbytes.Length);
        }

        private void msgListen_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
        }
    }
}
