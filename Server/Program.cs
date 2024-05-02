using Chat.MessageAgreement;
using Server;
using System.Net;
using System.Net.Sockets;

public class MyServer
{
    private static Dictionary<string, Socket> clientsDictionary = new();
    private static SystemMessages sysMsg= new();
    static void Main()
    { 
        ServerSocket serverParams = new();
        serverParams.SetServerIP();
        serverParams.SetSetverPort();
        if (serverParams.ServerIP == null)
        {
            Console.WriteLine("IP адрес null");
            return;
        }
        if (serverParams.ServerPort == null)
        {
            Console.WriteLine("Порт null");
            return;
        }
        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint serverEndPoint = new IPEndPoint(serverParams.ServerIP, (int)serverParams.ServerPort);
        serverSocket.Bind(serverEndPoint);
        serverSocket.Listen(10);
        Console.WriteLine("Сервер запущен. Ожидание подключений...");
        while (true)
        {
            Socket clientSocket = serverSocket.Accept();
            Console.WriteLine("Подключен клиент.");
            Thread clientThread = new Thread(HandleClient);
            clientThread.Start(clientSocket);
        }
    }
    private static void HandleClient(object client)
    {   
        Socket clientSocket = (Socket)client;
        IPEndPoint? clientEndPoint = (IPEndPoint?)clientSocket.RemoteEndPoint;
        if (clientEndPoint == null)
        {
            Console.WriteLine("Ошибка: клиент - null");
            return;
        }
        IPAddress clientIP = clientEndPoint.Address;
        int clientPort = clientEndPoint.Port;
        Console.WriteLine("IP-адрес клиента: " + clientIP + '\n' + "Порт клиента: " + clientPort);
        Client clientHandler = new();
        MessagePacket? message = clientHandler.GetMessage(clientSocket);
        if (message == null)
        {
            Console.WriteLine("Не удалось получить имя клиента.");
            return;
        }
        PrintLogs(message);
        try
        {
            clientsDictionary.Add(message.SenderName, clientSocket); //первое сообщение от клиента - его имя
        }
        catch (Exception)
        {
            Console.WriteLine("Такой клиент уже есть.");
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
            return;
        }
        Console.WriteLine("Имя нового клиента: " + message.SenderName);
        HandleChat(clientSocket, clientHandler, message.SenderName);
        clientSocket.Shutdown(SocketShutdown.Both);
        clientSocket.Close();

    }
    private static void HandleChat(Socket clientSocket, Client client, string senderName)
    {
        MessagePacket? messagePacket;
        Socket? targetClient;
        SystemMessages systemMessages = new SystemMessages();
        while (true)
        {
            if (clientSocket.Available > 0)
            {
                messagePacket = client.GetMessage(clientSocket);
                if (messagePacket == null)
                {
                    Console.WriteLine("Проблемы с передачей пакета.");
                    break;
                }
                PrintLogs(messagePacket);
                if (client.IsChatStop(messagePacket.SystemMessage))
                    break;
                if (messagePacket.SystemMessage == systemMessages.Update)
                {
                    if (clientsDictionary.TryGetValue(messagePacket.SenderName, out targetClient) == false)
                    {
                        Console.WriteLine("Клиент не найден в словаре.");
                        break;
                    }
                    string names = GetAllClientsName(messagePacket.SenderName);
                    client.SendMessage(targetClient, 
                    SetMessagePacket(sysMsg.ServerName, messagePacket.SenderName, sysMsg.Update, names));
                    PrintLogs(SetMessagePacket(sysMsg.ServerName, messagePacket.SenderName, sysMsg.Update, names));
                }
                else
                {
                    if (clientsDictionary.TryGetValue(messagePacket.TargetName, out targetClient) == false)
                    {
                        Console.WriteLine("Клиент не найден в словаре.");
                        break;
                    }
                    client.SendMessage(targetClient, messagePacket);
                    PrintLogs(messagePacket);
                }
            }
            Thread.Sleep(500);
        }
        clientsDictionary.Remove(senderName);
        Console.WriteLine(senderName + " отключился.");
    }

    private static MessagePacket SetMessagePacket(string sender, string target, string system, string message)
    {
        MessagePacket messagePacket = new MessagePacket();
        messagePacket.SenderName = sender;
        messagePacket.TargetName = target;
        messagePacket.SystemMessage = system;
        messagePacket.UsefulMessage = message;
        return messagePacket;
    }

    private static string GetAllClientsName(string askerName)
    {
        string result = "";
        foreach (var client in clientsDictionary.Keys) 
        {
            if (client != askerName)
                result += client + '#';
        }
        return result;
    }

    private static void PrintLogs(MessagePacket messagePacket)
    {
        Console.WriteLine("Целевой сокет: " + messagePacket.TargetName);
        Console.WriteLine("Отправитель : " + messagePacket.SenderName);
        Console.WriteLine("Системное сообщение: " + messagePacket.SystemMessage);
        Console.WriteLine("Полезное сообщение: " + messagePacket.UsefulMessage);
        Console.WriteLine("------------------------------------------------");
    }
}

