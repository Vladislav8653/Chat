using System.Net;
namespace Chat
{
    public partial class NewClient : Form
    {
        public NewClient()
        {
            InitializeComponent();
        }
        public IPAddress? IPAddress;
        public int Port;
        public string ClientName;

        private void NewClient_Deactivate(object sender, EventArgs e)
        {
            IP1.Clear();
            IP2.Clear();
            IP3.Clear();
            IP4.Clear();
            Port1.Clear();
            UserName.Clear();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (UserName.TextLength == 0)
            {
                MessageBox.Show("Введите имя", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string strIpAddress = IP1.Text.Trim() + "." + IP2.Text.Trim() + "." + IP3.Text.Trim()
                + "." + IP4.Text.Trim();
            try
            {
                IPAddress = IPAddress.Parse(strIpAddress);
            }
            catch (FormatException)
            {
                IPAddress = null;
                MessageBox.Show("Неверный формат IP-адреса", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int myPort;
            if (!int.TryParse(Port1.Text, out myPort))
            {
                Port = -1;
                MessageBox.Show("Неверный формат порта", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Port = myPort;
            ClientName = UserName.Text;
            this.Close();
        }

        private void NewClient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
            if (e.KeyCode == Keys.Space)
            {
                IP1.Text = "127";
                IP2.Text = "0";
                IP3.Text = "0";
                IP4.Text = "1";
                Port1.Text = "2000";
                UserName.Text = "Vlad";
            }
        }

        private void NewClient_Activated(object sender, EventArgs e)
        {
            Port = -1;
        }
    }
}
