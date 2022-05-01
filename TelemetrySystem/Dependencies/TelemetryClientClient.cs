using TelemetrySystem.Interfaces;

namespace TelemetrySystem.Dependencies
{
    public class TelemetryClientClient
    {
        // A class with the only goal of simulating a dependency on TelemetryClient
        // that has impact on the refactoring.
		public TelemetryClientClient(IClient tc)
        {
            //var tc = new TelemetryClient();
            if (!tc.OnlineStatus)
                tc.Connect("a connection string");

            tc.Send("some message");

            var response = tc.Receive();

            tc.Disconnect();

        }
    }
}
