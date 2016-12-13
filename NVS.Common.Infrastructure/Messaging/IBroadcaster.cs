using System;

namespace NVS.Common.Infrastructure.Messaging
{
    public interface IBroadcaster
    {
        void Publish(IMessage message);
        string Subscribe(string tag, Action<IMessage> handler);
        bool Unsubscribe(string token);
    }
}