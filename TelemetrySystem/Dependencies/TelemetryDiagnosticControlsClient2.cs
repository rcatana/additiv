using System;
using TelemetrySystem.Interfaces;

namespace TelemetrySystem.Dependencies
{
    public class TelemetryDiagnosticControlsClient2
    {
		// A class with the only goal of simulating a dependency on TelemetryDiagnosticControls
		// that has impact on the refactoring.

		public TelemetryDiagnosticControlsClient2(IDiagnosticControls teleDiagnostic)
		{
			//var teleDiagnostic = new TelemetryDiagnosticControls();

			teleDiagnostic.CheckTransmission();

			var result = teleDiagnostic.DiagnosticInfo;
		}
    }
}
