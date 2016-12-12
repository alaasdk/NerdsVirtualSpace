using System;

namespace NVS.Common.Infrastructure.Messaging
{
    public interface IBroadcaster
    {
        void Publish(Message message);
        string Subscribe(string tag, Action<Message> handler);
        bool Unsubscribe(string token);
    }
}