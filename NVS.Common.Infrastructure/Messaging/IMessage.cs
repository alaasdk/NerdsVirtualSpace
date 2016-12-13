namespace NVS.Common.Infrastructure.Messaging
{
    public interface IMessage
    {
        object Payload { get; set; }
        string Tag { get; set; }
    }

    public interface IMessage<T> : IMessage
    {
        new T Payload { get; set; }
    }
}