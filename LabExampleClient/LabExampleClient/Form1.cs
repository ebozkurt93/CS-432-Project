using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabExampleClient
{
    public partial class Form1 : Form
    {
        bool terminating = false;
        bool connected = false;

        Socket clientSocket;
        
        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            String IP = textIP.Text;
            int port;

            if (Int32.TryParse(textPort.Text, out port))
            {
                try
                {
                    clientSocket.Connect(IP, port);
                    connected = true;
                    buttonConnect.Enabled = false;
                    Thread receiveThread;
                    receiveThread = new Thread(new ThreadStart(Receive));
                    receiveThread.Start();
                    textLog.AppendText("Connected to server.\n");
                }
                catch
                {
                    textLog.AppendText("Could not connect.\n");
                }
            }
            else
            {
                textLog.AppendText("Check port.");
            }
        }

        private void Receive()
        {
            while (connected)
            {
                try
                {
                    Byte[] buffer = new Byte[64];
                    clientSocket.Receive(buffer);

                    String incomingMessage = Encoding.Default.GetString(buffer);
                    incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf('\0'));
                    textLog.AppendText(incomingMessage + "\n");
                }
                catch
                {
                    if (!terminating)
                    {
                        textLog.AppendText("Lost connection to server.\n");
                        buttonConnect.Enabled = true;
                    }
                    connected = false;
                    clientSocket.Close();
                    clientSocket = null;
                }
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            String message = textMessage.Text;

            if (message != "" && message.Length < 63)
            {
                Byte[] buffer = new Byte[64];
                buffer = Encoding.Default.GetBytes(message);
                clientSocket.Send(buffer);
            }
        }

        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Do you want to exit?", "Client",
                MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                connected = false;
                terminating = true;
                Environment.Exit(0);
            }
        }

        private void textIP_TextChanged(object sender, EventArgs e)
        {

        }

        private void textPort_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
