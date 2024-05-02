using Chat.MessageAgreement;
using Server;
using System.Net;
using System.Net.Sockets;

namespace Chat
{
    public partial class MainForm : Form
    {
        private NewClient _newClient = new();
        private SystemMessages _systemMessages = new();
        //private Dictionary<string, Socket> _clientsDictionary = new();
        private Socket _serverSocket;
        private Client _clientHandler = new();
        private string _clientName;
        private List<System.Windows.Forms.Label> messagesList = new List<System.Windows.Forms.Label>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            string text = MessageTextBox.Text;
            if (text != "")
            {
                _clientHandler.SendMessage(_serverSocket,
                   SetMessagePacket(_clientName, Client1Name.Text, " ", text));
                SendBtn.Enabled = false;
                MessageTextBox.Text = "";
                int rightBorder = SendBtn.Right;
                System.Windows.Forms.Label label = CreateLabelMessage(true, rightBorder, 0, SendBtn.Top, text);
                messagesList.Add(label);
                Controls.Add(label);
                for (int i = messagesList.Count - 2; i >= 0; i--)
                {
                    messagesList[i].Top = messagesList[i + 1].Top - 30 * (messagesList[i + 1].Text.Length/29 + 1);
                }
            }
        }

        private async void Client1PictuteBox_Click(object sender, EventArgs e)
        {
            Client1PictuteBox.BorderStyle = BorderStyle.Fixed3D;
            SendBtn.Enabled = true;
            int leftBorder = MessageTextBox.Left;

            await Task.Run(() =>
            {
                while (true)
                {
                    if (_serverSocket.Available > 0)
                    {
                        MessagePacket? messagePacket = _clientHandler.GetMessage(_serverSocket);
                        if (messagePacket == null)
                        {
                            MessageBox.Show("Полученное сообщение от " + Client1Name.Text + " не удалось распарсить", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        SendBtn.Enabled = true;
                        string text = messagePacket.UsefulMessage;
                        System.Windows.Forms.Label label = CreateLabelMessage(false, 0, leftBorder, SendBtn.Top, text);
                        messagesList.Add(label);
                        for (int i = messagesList.Count - 2; i >= 0; i--)
                        {
                            messagesList[i].Top = messagesList[i + 1].Top - 30;
                        }
                        Invoke((MethodInvoker)delegate
                        {
                            Controls.Add(label);
                        });

                    }
                }
            });
        }



        private System.Windows.Forms.Label CreateLabelMessage(bool isSend, int rightBorder, int leftBorder, int y, string text)
        {
            System.Windows.Forms.Label message = new();
            if (text.Length > 29)
            {
                message.Width = 350;
                int stringNumber = (text.Length / 29) + 1;
                message.Height = 25 * stringNumber;
            }
            else
            {
                message.Width = 13 * text.Length;
                message.Height = 25;
            }
            message.Font = new Font("Arial", 12, FontStyle.Bold);
            message.Text = text;
            //message.BorderStyle = BorderStyle.Fixed3D;
            if (isSend)
            {
                message.TextAlign = ContentAlignment.TopRight;
                message.Location = new Point(rightBorder - message.Width, y - 20 - message.Height);

            }
            else
            {
                message.TextAlign = ContentAlignment.TopLeft;
                message.Location = new Point(leftBorder, y - 20 - message.Height);
            }
            return message;
        }

        
        private void CreateChatBtn_Click(object sender, EventArgs e)
        {
            _newClient.ShowDialog();
            if (_newClient.IPAddress == null || _newClient.Port == -1)
                return;
            IPAddress serverIpAddress = _newClient.IPAddress;
            int port = _newClient.Port;
            try
            {
                IPEndPoint serverEndPoint = new IPEndPoint(serverIpAddress, port);
                _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _serverSocket.Connect(serverEndPoint); //подключилсь
                _clientName = _newClient.ClientName;
                _clientHandler.SendMessage(_serverSocket,
                    SetMessagePacket(_clientName, _systemMessages.ServerName, " ", " "));
                CreateChatBtn.BackColor = Color.LightGreen;
                CreateChatBtn.Text = "Подключение установлено";
                AddUserButton.Visible = true;

            }
            catch (Exception)
            {
                _serverSocket.Close();
                MessageBox.Show("Сервер не отвечает.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CreateUser(string name)
        {
            Client1PictuteBox.Visible = true;
            Client1Name.BackColor = Client1PictuteBox.BackColor;
            Client1Name.Text = name;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_serverSocket != null)
                if (_serverSocket.Connected)
                {
                    _clientHandler.SendMessage(_serverSocket,
                        SetMessagePacket(_clientName, _systemMessages.ServerName, _systemMessages.Stop, " "));
                    Thread.Sleep(500);
                }
        }

        private MessagePacket SetMessagePacket(string sender, string target, string system, string message)
        {
            MessagePacket messagePacket = new MessagePacket();
            messagePacket.SenderName = sender;
            messagePacket.TargetName = target;
            messagePacket.SystemMessage = system;
            messagePacket.UsefulMessage = message;
            return messagePacket;
        }

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            try
            {
                _clientHandler.SendMessage(_serverSocket,
                    SetMessagePacket(_clientName, _systemMessages.ServerName, _systemMessages.Update, " "));
            }
            catch (Exception)
            {
                MessageBox.Show("Сообщение не удалось отправить.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessagePacket? messageGetPacket = _clientHandler.GetMessage(_serverSocket);
            if (messageGetPacket == null)
            {
                MessageBox.Show("Не удалось распарсить полученное сообщение.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (messageGetPacket.SystemMessage == _systemMessages.Update)
            {
                string[] names = messageGetPacket.UsefulMessage.Split('#');
                for (int i = 0; i < names.Length; i++)
                {
                    if (names[i] != "")
                    {
                        CreateUser(names[i]);
                    }
                }
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && SendBtn.Enabled)
            {
                SendBtn_Click(sender, e);
            }
        }
    }
}