namespace TelemetrySystem.Interfaces
{
    public interface IMessaging
    {
        void Send(string message);
        string Receive();
    }
}
