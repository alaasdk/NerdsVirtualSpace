using System;

namespace NVS.Common.Infrastructure.Messaging
{
    public interface IBroadcaster<T> 
    {
        void Publish(IMessage<T> message);
        string Subscribe(string tag, Action<IMessage<T>> handler);
        bool Unsubscribe(string token);
    }
}