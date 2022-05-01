namespace TelemetrySystem.Interfaces
{
    public interface IDiagnosticControls
    {
        string DiagnosticInfo { get; set; }
        void CheckTransmission();
    }
}
