using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabExampleServer
{
    public partial class Form1 : Form
    {

        private RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();


        bool terminating = false;
        bool listening = false;
        bool remoteConnected = false;

        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        Socket remoteSocket;
        List<Socket> socketList = new List<Socket>();
        List<String> usernameList = new List<String>();

        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
        }

        private void buttonListen_Click(object sender, EventArgs e)
        {
            int serverPort;
            Thread acceptThread;

            if (Int32.TryParse(textPort.Text, out serverPort))
            {
                serverSocket.Bind(new IPEndPoint(IPAddress.Any, serverPort));
                serverSocket.Listen(5);

                listening = true;
                buttonListen.Enabled = false;
                acceptThread = new Thread(new ThreadStart(Accept));
                acceptThread.Start();

                textLog.AppendText("Started listening on port: " + serverPort + "\n");
            }
            else
            {
                textLog.AppendText("Check port.\n");
            }
        }

        private void Accept()
        {
            while (listening)
            {
                try
                {
                    socketList.Add(serverSocket.Accept());
                    textLog.AppendText("A client connected.\n");

                    Thread receiveThread;
                    receiveThread = new Thread(new ThreadStart(Receive));
                    receiveThread.Start();
                }
                catch
                {
                    if (terminating)
                        listening = false;
                    else
                        textLog.AppendText("The socket stopped working.\n");
                }
            }
        }

        private void Receive()
        {
            Socket s = socketList[socketList.Count - 1];
            bool connected = true;

            while (connected && !terminating)
            {
                try
                {
                    Byte[] buffer = new Byte[64];
                    s.Receive(buffer);

                    string incomingMessage = Encoding.Default.GetString(buffer);
                    incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf('\0'));
                    textLog.AppendText(incomingMessage + "\n");

                    //sending random number
                    // Create a byte array to hold the random value. (32B -> 256-bit in this example)
                    byte[] randomNumber = new byte[16];

                    // Fill the array with a random value.
                    rngCsp.GetBytes(randomNumber);

                    // Display the resulting random number as a hexadecimal string.
                    string hexResult = (generateHexStringFromByteArray(randomNumber));
                    //send hexResult to client
                    buffer = Encoding.Default.GetBytes(hexResult);
                    s.Send(buffer);


                    /*
                    if (remoteConnected)
                    {
                        try
                        {
                            // send math operation
                            remoteSocket.Send(buffer);

                            // receive the answer
                            buffer = new Byte[64];
                            remoteSocket.Receive(buffer);

                            // send answer to the client
                            s.Send(buffer);
                        }
                        catch
                        {
                            remoteConnected = false;
                            remoteSocket = null;
                            buttonConnect.Enabled = true;
                        }
                    }
                    else
                    {
                        buttonConnect.Enabled = true;
                        textLog.AppendText("Not connected to remote server.\n");
                    } */
                }
                catch
                {
                    if (!terminating)
                        textLog.AppendText("A client has disconnected.\n");

                    s.Close();
                    socketList.Remove(s);
                    connected = false;
                }
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            remoteSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            String IP = textRemoteIP.Text;
            int port;

            if (Int32.TryParse(textRemotePort.Text, out port))
            {
                try
                {
                    remoteSocket.Connect(IP, port);
                    remoteConnected = true;
                    buttonConnect.Enabled = false;
                    textLog.AppendText("Connected to remote math server.\n");
                }
                catch
                {
                    textLog.AppendText("Could not connect to the remote server.\n");
                }
            }
            else
            {
                textLog.AppendText("Check port.\n");
            }
        }

        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Do you want to exit?", "Server",
                MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                listening = false;
                terminating = true;
                Environment.Exit(0);
            }
        }

        private void textPort_TextChanged(object sender, EventArgs e)
        {

        }

        private void clearLogBtn_Click(object sender, EventArgs e)
        {
            textLog.Clear();
        }

        private string generateHexStringFromByteArray(byte[] input)
        {
            string hexString = BitConverter.ToString(input);
            return hexString.Replace("-", "");
        }
    }
}
