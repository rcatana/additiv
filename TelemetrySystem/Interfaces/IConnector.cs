namespace TelemetrySystem.Interfaces
{
    public interface IConnector
    {
        void Connect(string connString);
        void Disconnect();
    }
}
