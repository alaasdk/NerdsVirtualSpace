namespace NVS.Common.Infrastructure.Messaging
{
    public interface IMessage<T>
    {
        T Payload { get; set; }
        string Tag { get; set; }
    }
}