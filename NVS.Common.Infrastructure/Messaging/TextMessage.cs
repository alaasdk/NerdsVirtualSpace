using System;

namespace NVS.Common.Infrastructure.Messaging
{
    public class TextMessage : IMessage<string>
    {
        public string Payload { get; set; }
        public string Tag { get; set; }

        object IMessage.Payload
        {
            get { return this.Payload; }

            set { this.Payload = value.ToString(); }
        }

        public TextMessage(string payload, string tag)
        {
            this.Payload = payload;
            this.Tag = tag;
        }

        public override string ToString()
        {
            return this.Payload;
        }
    }
}