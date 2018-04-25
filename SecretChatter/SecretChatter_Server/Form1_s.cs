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
using System.Security.Cryptography;
using System.IO;

namespace SecretChatter_Server
{
    public partial class Form1_s : Form
    {
        DES DESalg = DES.Create("DES");
        byte[] iv = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };
        string password;
        byte[] key;
        string username;
        int byteSize=0;
        const int port = 8081;
        byte[] writebytes = new byte[1024];
        byte[] readbytes = new byte[1024];
        TcpListener server = new TcpListener(IPAddress.Any, port);
        string data = null;
        NetworkStream stream;
        TcpClient tcp_client;
        bool authenticated = false;
        byte[] challange = new byte[1];

        public Form1_s()
        {
            
            InitializeComponent();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            key = getHash(inputPassword.Text);
           // messageLog.Text += "\r\n" + key.Length + "\r\n" + iv.Length;
           //Send current message
            
            if (inputText.Text.Length > 0)
            {
                byte[] Data = EncryptTextToMemory(inputText.Text, key, iv);
                string result = System.Text.Encoding.Unicode.GetString(Data);
                byte[] dataB = System.Text.Encoding.Unicode.GetBytes(result);
                string Final = DecryptTextFromMemory(dataB, key, iv);
                messageLog.Text += "\r\n " + username + ": " + " " + "Original text: " + inputText.Text + "\r\n\t" + "Encrypted text: " + Convert.ToBase64String(Data) + "\r\n";
                //writebytes = System.Text.Encoding.Unicode.GetBytes("\r\n " + username + ": " + " " + "Received text: " + result + "\r\n\t" + "Decrypted text: ");
                writebytes = System.Text.Encoding.Unicode.GetBytes(result);
                stream.Write(Data, 0, Data.Length);
                inputText.Text = "";
            }
            
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            key = getHash(inputPassword.Text);
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

            //Send Client a random challange
            Random rnd = new Random();
            rnd.NextBytes(challange);
            stream.Write(challange, 0, challange.Length);
            messageLog.Text += "Sending authentication challange: " + Convert.ToUInt16(challange[0]) + "\r\n";
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
                byte[] tempArray = new byte[1 + key.Length];
                byte[] tempArray2 = new byte[byteSize];
                tempArray[0] = challange[0];
                for (int i = 0; i < key.Length; i++)
                {
                    tempArray[i + 1] = key[i];
                }
                for (int i = 0; i < byteSize; i++)
                {
                    tempArray2[i] = readbytes[i];
                }

                if (getHash(tempArray).SequenceEqual(tempArray2))
                {
                    messageLog.Text += ("Authentication Successful!" + "\r\n");
                    authenticated = true;
                     
                }
                else
                {
                    messageLog.Text += ("Authentication Failed!" + "\r\n");
                    authenticated = true;
                }
            }
            else
            {
                // Translate data bytes to a ASCII string and print to messageLog
                key = getHash(inputPassword.Text);
                byte[] tempArray = new byte[byteSize];
                Buffer.BlockCopy(readbytes, 0, tempArray, 0, byteSize);
                string Output = DecryptTextFromMemory(tempArray, key, iv);
                messageLog.Text += ("\r\n Received message:" + Convert.ToBase64String(tempArray) + "\r\n Decrypted message:" + Output + "\r\n");

                Array.Clear(readbytes, 0, readbytes.Length);
            }
            
        }

        private void msgListen_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
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
        private static byte[] getHash(byte[] data)
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

        private void inputPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
