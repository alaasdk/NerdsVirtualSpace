namespace NVS.Common.Infrastructure.Messaging
{
    public class Message
    {
        public string Payload { get; set; }
        public string Tag { get; set; }

        public Message(string payload, string tag)
        {
            this.Payload = payload;
            this.Tag = tag;
        }
    }
}