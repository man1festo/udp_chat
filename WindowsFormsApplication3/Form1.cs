using System;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;
using System.Media;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public string srcPath;
        public string initPath;
        private const int BufferSize = 1024;
        string FileName;
        long FileSize;
        Thread recFile = null;
        UdpClient udpFile = new UdpClient();
        Thread recChat = null;
        UdpClient udpChat = new UdpClient();
        bool stopReceive = false;
        bool stopUDPReceive = false;
        double integrity = 0;
        double chck;

        IPEndPoint ipendpoint = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        private void startMS_Click(object sender, EventArgs e)
        {
            stopReceive = false;
            udpChat = new UdpClient(8080);
            recChat = new Thread(new ThreadStart(Receive));
            recChat.Start();
            startMS.Visible = false;
            stopMS.Visible = true;

        }
          void Receive()
        {
            try
            {
                while (true)
                {
                    if (stopReceive == true)
                    {
                        break;
                    }
                    IPEndPoint ipendpoint = null;
                    byte[] message = udpChat.Receive(ref ipendpoint);

                    if (messageBOX.InvokeRequired)
                    {
                        ShowMessageCallback dt = new ShowMessageCallback(ShowMessage);
                        Invoke(dt, new object[] { Encoding.Default.GetString(message) });
                    }
                    else
                    {
                        ShowMessage(Encoding.Default.GetString(message));
                    }
                    

                }

            }


            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        delegate void ShowMessageCallback(string message);
        void ShowMessage(string message)
        {

                messageBOX.Text = message;
        }
            
        

        
        void StopRecFile()
        {
            stopUDPReceive = true;
            recFile.Abort();
            udpFile.Close();
        }

        void RecFile()
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false; // Отключаем проверку использования потоками контроллов.
            while (true)
            {
                if (stopUDPReceive == true)
                {
                    break;
                }
                while (true)
                {
                    byte[] name = udpFile.Receive(ref ipendpoint);
                    FileName = Encoding.Default.GetString(name);
                    break;
                }
                while (true)
                {
                    byte[] size = udpFile.Receive(ref ipendpoint);
                    string size1 = Encoding.Default.GetString(size);
                    FileSize = long.Parse(size1);
                    break;
                }


                FileStream FS = new FileStream(FileName, FileMode.Create, FileAccess.Write);
                progressBar1.Maximum = (Convert.ToInt32(Math.Ceiling(Convert.ToDouble(FileSize) / Convert.ToDouble(BufferSize))));
                progressBar1.Value = progressBar1.Minimum;
                byte[] file;
                while (true)
                {
                    file = udpFile.Receive(ref ipendpoint);
                    FS.Write(file, 0, file.Length);
                    progressBar1.PerformStep();
                    if (file.Length < BufferSize)
                    {

                        break;
                    }


                }
                FS.Close();
                FileStream Check = new FileStream(FileName, FileMode.Open, FileAccess.Read);
                chck = Check.Length / FileSize * 100;
                MessageBox.Show("Файл " + FileName + " успешно принят. Целостность: " + chck + "%");
                Check.Close();

            }

        }

      
        private void StopReceive()
        {
            stopReceive = true;
            if (udpChat != null)
            {
                udpChat.Close();
            }
            if (recChat != null)
            {
                recChat.Abort();
            }
        }

        private void stopMS_Click(object sender, EventArgs e)
        {
            StopReceive();
            startMS.Visible = true;
            stopMS.Visible = false;
        }

        private void startFS_Click(object sender, EventArgs e)
        {
            stopUDPReceive = false;
            udpFile = new UdpClient(8081);
            recFile = new Thread(new ThreadStart(RecFile));
            recFile.Start();
            startFS.Visible = false;
            stopFS.Visible = true;

        }

        private void stopFS_Click(object sender, EventArgs e)
        {
            StopRecFile();
            startFS.Visible = true;
            stopFS.Visible = false;
        }
    }
}
    


