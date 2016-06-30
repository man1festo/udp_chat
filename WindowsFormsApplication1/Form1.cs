using System;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        string intPath;
        int bufferSize = 1024;

        public Form1()
        {
            InitializeComponent();
        }
        void SendMessage()
        {
            IPAddress IP = IPAddress.Parse(recIP.Text);
            IPEndPoint ipendpoint = new IPEndPoint(IP, 8080);
            UdpClient udp = new UdpClient();
            byte[] message = Encoding.Default.GetBytes(messageBox.Text);
            udp.Send(message, message.Length, ipendpoint);
            udp.Close();
            messageBox.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            intPath = Environment.CurrentDirectory;
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = intPath;
            if(file.ShowDialog() == DialogResult.OK)
            {
                string path = file.FileName;
                filePath.Text = path;
            }
                
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IPEndPoint ipendpoint = new IPEndPoint(IPAddress.Parse(recIP.Text), 8081);
            FileStream FS = new FileStream(filePath.Text, FileMode.Open, FileAccess.Read);
            byte[] fileName = Encoding.Default.GetBytes(System.IO.Path.GetFileName(filePath.Text));
            UdpClient nameUDP = new UdpClient();
            nameUDP.Send(fileName, fileName.Length, ipendpoint);
            nameUDP.Close();
            byte[] size = Encoding.Default.GetBytes(FS.Length.ToString());
            UdpClient sizeUDP = new UdpClient();
            sizeUDP.Send(size, size.Length, ipendpoint);
            sizeUDP.Close();
            byte[] buffer;
            int NoPackets = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(FS.Length) / Convert.ToDouble(bufferSize)));
            progressBar1.Maximum = NoPackets;
            progressBar1.Value = progressBar1.Maximum;
            long totalBytes = FS.Length;
            int bytes;
            UdpClient fileUDP = new UdpClient();
            for (int i = 0; i < NoPackets; i++)
            {
                if (totalBytes >= bufferSize)
                {
                    bytes = bufferSize;
                    totalBytes = totalBytes - bufferSize;
                }
                else
                {
                    bytes = (int)totalBytes;
                }
                buffer = new byte[bytes];
                FS.Read(buffer, 0, buffer.Length);
                fileUDP.Send(buffer, buffer.Length, ipendpoint);
                progressBar1.PerformStep();

            }
            fileUDP.Close();
            FS.Close();


        }
    }
}
