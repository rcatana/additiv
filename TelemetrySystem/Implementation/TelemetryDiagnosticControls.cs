using System;
using TelemetrySystem.Interfaces;

namespace TelemetrySystem.Implementation
{
    public class TelemetryDiagnosticControls : IDiagnosticControls
    {
        private const string DiagnosticChannelConnectionString = "*111#";

        private readonly IClient _telemetryClient;
        private string _diagnosticInfo = string.Empty;

        public TelemetryDiagnosticControls(IClient telemetryClient)
        {
            _telemetryClient = telemetryClient;
        }

        public string DiagnosticInfo
        {
            get { return _diagnosticInfo; }
            set { _diagnosticInfo = value; }
        }

        public void CheckTransmission()
        {
            if (_telemetryClient.OnlineStatus == false)
            {
                throw new Exception("Unable to connect.");
            }
            SendMessage();
        }

        public bool EstablishConnection()
        {
            _telemetryClient.Disconnect();

            int retryLeft = 3;
            while (_telemetryClient.OnlineStatus == false && retryLeft > 0)
            {
                _telemetryClient.Connect(DiagnosticChannelConnectionString);
                retryLeft -= 1;
            }
            return _telemetryClient.OnlineStatus;
        }

        public void SendMessage()
        {
            _diagnosticInfo = string.Empty;
            _telemetryClient.Send(TelemetryClient.DiagnosticMessage);
            _diagnosticInfo = _telemetryClient.Receive();
        }
    }
}
