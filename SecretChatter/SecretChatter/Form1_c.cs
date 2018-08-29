using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Security.Cryptography;
using System.IO;

namespace SecretChatter
{

    public partial class Form1_c : Form
    {
        DES DESalg = DES.Create("DES");
        byte[] iv = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };
        string username;
        string password;
        static string ipstring;
        IPEndPoint targetIP;
        TcpClient tcp_client = new TcpClient();
        NetworkStream stream;
        byte[] readbytes = new byte[1024];
        byte[] writebytes = new byte[1024];
        byte[] key;
        int byteSize = 0;
        bool authenticated = false;

        public Form1_c()
        {           
            InitializeComponent();
        }

        private void sendMessage()
        {
            key = getHash(inputPassword.Text);
            //Send current message
            if (inputText.Text.Length > 0)
            {
                byte[] Data = EncryptTextToMemory(username + ": " + inputText.Text, key, iv);
                string result = System.Text.Encoding.Unicode.GetString(Data);
                byte[] dataB = System.Text.Encoding.Unicode.GetBytes(result);
                messageLog.Text += username + ": " + " " + inputText.Text + "\r\n";
                stream.Write(Data, 0, Data.Length);
                inputText.Text = "";
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            sendMessage();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            key = getHash(inputPassword.Text);
            username = inputUsername.Text;
            password = inputPassword.Text;
            ipstring = inputIP.Text;
            targetIP = new IPEndPoint(IPAddress.Parse(ipstring), 8081);
            tcp_client.Connect(targetIP);
            stream = tcp_client.GetStream();
            //Feedback after connection
            if (tcp_client.Connected)
            {
                messageLog.Text += "Successful Connection!\r\n";
                this.msgListen.RunWorkerAsync();

            }
            else
            {
                messageLog.Text += "Connection Unsuccessful...\r\n";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void msgListen_DoWork(object sender, DoWorkEventArgs e)
        {

            while ((byteSize = stream.Read(readbytes, 0, readbytes.Length)) > 0)
            {
                //Report progress
                this.msgListen.ReportProgress(1);
            }

        }

        private void msgListen_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (authenticated == false)
            {
                //RESPOND TO CHALLANGE
                messageLog.Text += ("Received challange:" + Convert.ToUInt16(readbytes[0]) + "\r\n");
                messageLog.Text += ("Responding to challange... \r\n");
                byte[] tempArray = new byte[byteSize + key.Length];
                tempArray[0] = readbytes[0];
                for (int i = 0; i < key.Length; i++)
                {
                    tempArray[i + 1] = key[i];
                }

                stream.Write(getHash(tempArray), 0, getHash(tempArray).Length);
                authenticated = true;

            }
            else
            {
                // Translate data bytes to a ASCII string and print to messageLog
                key = getHash(inputPassword.Text);
                byte[] tempArray = new byte[byteSize];
                Buffer.BlockCopy(readbytes, 0, tempArray, 0, byteSize);
                string Output = DecryptTextFromMemory(tempArray, key, iv);
                messageLog.Text += Output;
                messageLog.Text += "\r\n";

                Array.Clear(readbytes, 0, readbytes.Length);
            }
            
        }

        public static byte[] EncryptTextToMemory(string Data, byte[] key, byte[] iv)
        {
            try
            {
                // Create a MemoryStream.
                MemoryStream mStream = new MemoryStream();

                // Create a new DES object.
                DES DESalg = DES.Create();

                // Create a CryptoStream using the MemoryStream 
                // and the passed key and initialization vector (IV).
                CryptoStream cStream = new CryptoStream(mStream,
                    DESalg.CreateEncryptor(key, iv),
                    CryptoStreamMode.Write);

                // Convert the passed string to a byte array.
                byte[] toEncrypt = System.Text.Encoding.Unicode.GetBytes(Data);

                // Write the byte array to the crypto stream and flush it.
                cStream.Write(toEncrypt, 0, toEncrypt.Length);
                cStream.FlushFinalBlock();

                // Get an array of bytes from the 
                // MemoryStream that holds the 
                // encrypted data.
                byte[] ret = mStream.ToArray();

                // Close the streams.
                cStream.Close();
                mStream.Close();

                // Return the encrypted buffer.
                return ret;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }

        }
    

    public static string DecryptTextFromMemory(byte[] Data, byte[] key, byte[] iv)
        {
            try
            {
                // Create a new MemoryStream using the passed 
                // array of encrypted data.
                MemoryStream msDecrypt = new MemoryStream(Data);

                // Create a new DES object.
                DES DESalg = DES.Create();

                // Create a CryptoStream using the MemoryStream 
                // and the passed key and initialization vector (IV).
                CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                    DESalg.CreateDecryptor(key, iv),
                    CryptoStreamMode.Read);

                // Create buffer to hold the decrypted data.
                byte[] fromEncrypt = new byte[Data.Length];

                // Read the decrypted data out of the crypto stream
                // and place it into the temporary buffer.
                csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

                //Convert the buffer into a string and return it.
                return System.Text.Encoding.Unicode.GetString(fromEncrypt);
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
        }

        private static byte[] getHash(string word)
        {

            byte[] data = System.Text.Encoding.ASCII.GetBytes(word);
            byte[] result;

            SHA1 sha = new SHA1CryptoServiceProvider();
            // This is one implementation of the abstract class SHA1.
            result = sha.ComputeHash(data);
            byte[] newArray = new byte[8];
            for (int i = 0; i < 8; i++)
            {
                newArray[i] = result[i];
            }

            return newArray;


        }
        private static byte[] getHash (byte[] data)
        {
            byte[] result;

            SHA1 sha = new SHA1CryptoServiceProvider();
            // This is one implementation of the abstract class SHA1.
            result = sha.ComputeHash(data);
            byte[] newArray = new byte[8];
            for (int i = 0; i < 8; i++)
            {
                newArray[i] = result[i];
            }

            return newArray;


        }

        private void inputText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                sendMessage();
            }
        }
    }
}

