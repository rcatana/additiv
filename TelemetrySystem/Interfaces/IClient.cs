namespace TelemetrySystem.Interfaces
{
    public interface IClient : IConnector, IMessaging
    {
        bool OnlineStatus { get; set; }
    }
}
