namespace Server
{
    [Serializable]
    public class MessagePacket
    {
        
        public string SenderName { get; set; }
        public string TargetName { get; set; }
        public string SystemMessage { get; set; }
        public string UsefulMessage { get; set; }

       
    }
}
