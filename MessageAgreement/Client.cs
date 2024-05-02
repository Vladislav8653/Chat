using System.Net.Sockets;
using System.Text.Json;

namespace Server
{
    public class Client
    {
        public bool IsChatStop(string systemMessage)
        {
            const string stopMessage = "stop";
            if (systemMessage == stopMessage)
            {
                return true;
            }
            return false;
        }
        public void SendMessage(Socket targetSocket, MessagePacket messagePacket)
        {
            targetSocket.Send(RepresentMessagePacketAsByteArray(messagePacket));
            Thread.Sleep(200);
        }
        public MessagePacket? GetMessage(Socket socket)
        {
            int bytesRead; 
            byte[] inputData = new byte[256]; 
            do
            {
                bytesRead = socket.Receive(inputData);
            }
            while (bytesRead > 0);
            Console.WriteLine(DateTime.Now.ToShortTimeString() + ": " + inputData.ToString());
            return AnalyseMessage(inputData);
        }
        public MessagePacket CreateMessage(string senderName, string targetName, string systemMessage, string usefulMessage)
        {
            MessagePacket messagePacket = new MessagePacket
            {
                SenderName = senderName,
                TargetName = targetName,
                SystemMessage = systemMessage,
                UsefulMessage = usefulMessage,
            };
            return messagePacket;
        }
        private MessagePacket? AnalyseMessage(byte[] message)
        {
            MessagePacket? messagePacket = JsonSerializer.Deserialize<MessagePacket>(message);
            return messagePacket;
        }

        private byte[] RepresentMessagePacketAsByteArray(MessagePacket messagePacket)
        {
            return JsonSerializer.SerializeToUtf8Bytes(messagePacket);
        }
    }
}
