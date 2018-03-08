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

namespace SecretChatter_Server
{
    public partial class Form1 : Form
    {
        bool receive = false;
        const int port = 8081;
        byte[] bytes = new byte[1024];
        string data;
        TcpListener server = new TcpListener(IPAddress.Any, port);
        public Form1()
        {
            InitializeComponent();
            
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {

        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            server.Start();
            var client = server.AcceptTcpClientAsync();
        }
    }
}
