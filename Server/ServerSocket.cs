using System.Net;
using System.Net.Sockets;

public class ServerSocket
{
    public IPAddress? ServerIP { get; private set; }
    public ushort? ServerPort  { get; private set; }
    public void SetServerIP ()
    {
        this.ServerIP = GetServerIP(RequestServerIP());
    }
    public void SetSetverPort()
    {
        this.ServerPort = GetServerPort(this.ServerIP);
    }
    private string? RequestServerIP()
    {
        string? serverIPstring;
        bool isInputCorrect;
        IPAddress? testServerIP;
        do
        {
            isInputCorrect = true;
            Console.WriteLine("Введите IP адрес сервера (чтобы использовать localhost, отправьте #):");
            serverIPstring = Console.ReadLine();
            if (serverIPstring == "#")
            {
                serverIPstring = "127.0.0.1";
            }
            else
            {
                if (!IPAddress.TryParse(serverIPstring, out testServerIP))
                {
                    Console.WriteLine("Введите верный IP.");
                    isInputCorrect = false;
                }
            }
        } while (!isInputCorrect);
        return serverIPstring;
    }
    private IPAddress? GetServerIP(string? serverIPstring)
    {
        IPAddress? serverIP;
        if (!IPAddress.TryParse(serverIPstring, out serverIP))
        {
           return null;
        }
        return serverIP;
    }
    private ushort RequestServerPort()
    {
        bool isInputCorrect;
        ushort serverPort;
        do
        {
            isInputCorrect = true;
            Console.WriteLine("Введите порт:");
            if (!ushort.TryParse(Console.ReadLine(), out serverPort))
            {
                Console.WriteLine("Введите верный порт.");
                isInputCorrect = false;
            }
        } while (!isInputCorrect);
        return serverPort;
    }
    private ushort? GetServerPort(IPAddress? serverIP)
    {
        if (serverIP == null)
            return null;
        bool isInputCorrect;
        ushort serverPort;
        do
        {
            isInputCorrect = true;
            serverPort = RequestServerPort();
            if (!IsPortAvailable(serverPort, serverIP))
            {
                Console.WriteLine("Введите другой порт, так как этот занят.");
                isInputCorrect = false;
            }
        } while (!isInputCorrect);
        return serverPort;
    }
    private bool IsPortAvailable(int port, IPAddress serverIP)
    {
        bool isAvailable;
        using Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        try
        {
            socket.Bind(new IPEndPoint(serverIP, port));
            isAvailable = true;
        }
        catch (SocketException)
        {
            isAvailable = false;
        }
        return isAvailable;
    }
}
