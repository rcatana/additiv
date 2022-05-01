using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TelemetrySystem.Implementation;

namespace TelemetrySystemTests
{
    [TestClass]
    public class TelemetryDiagnosticControlsTest
    {
        [TestMethod]
        public void CheckTransmision_Receive_Unsuccessful_Message()
        {
            //arange
            var telemetryClient = new TelemetryClient();
            telemetryClient.OnlineStatus = false;
            var diagnosticControls = new TelemetryDiagnosticControls(telemetryClient);
            //act
            try
            {
                diagnosticControls.CheckTransmission();
            }
            catch (Exception ex)
            {
                //assert
                Assert.AreEqual(ex.Message, "Unable to connect.");
            }
        }

        [TestMethod]
        public void CheckTransmision_Receive_Successful_Message()
        {
            //arange
            var message = "LAST TX rate................ 100 MBPS\r\n"
                    + "HIGHEST TX rate............. 100 MBPS\r\n"
                    + "LAST RX rate................ 100 MBPS\r\n"
                    + "HIGHEST RX rate............. 100 MBPS\r\n"
                    + "BIT RATE.................... 100000000\r\n"
                    + "WORD LEN.................... 16\r\n"
                    + "WORD/FRAME.................. 511\r\n"
                    + "BITS/FRAME.................. 8192\r\n"
                    + "MODULATION TYPE............. PCM/FM\r\n"
                    + "TX Digital Los.............. 0.75\r\n"
                    + "RX Digital Los.............. 0.10\r\n"
                    + "BEP Test.................... -5\r\n"
                    + "Local Rtrn Count............ 00\r\n"
                    + "Remote Rtrn Count........... 00";
            var telemetryClient = new TelemetryClient();
            telemetryClient.OnlineStatus = true;
            var diagnosticControls = new TelemetryDiagnosticControls(telemetryClient);
            //act
            diagnosticControls.CheckTransmission();
            //assert
            Assert.AreEqual(diagnosticControls.DiagnosticInfo, message);
        }

        [TestMethod]
        public void EstablishConnection_TryToEstablishConnection()
        {
            //arange
            var diagnosticControls = new TelemetryDiagnosticControls(new TelemetryClient());
            //act
            var result = diagnosticControls.EstablishConnection();
            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SendMessage_Message_Received_As_Expected()
        {
            //arange
            var message = "LAST TX rate................ 100 MBPS\r\n"
                    + "HIGHEST TX rate............. 100 MBPS\r\n"
                    + "LAST RX rate................ 100 MBPS\r\n"
                    + "HIGHEST RX rate............. 100 MBPS\r\n"
                    + "BIT RATE.................... 100000000\r\n"
                    + "WORD LEN.................... 16\r\n"
                    + "WORD/FRAME.................. 511\r\n"
                    + "BITS/FRAME.................. 8192\r\n"
                    + "MODULATION TYPE............. PCM/FM\r\n"
                    + "TX Digital Los.............. 0.75\r\n"
                    + "RX Digital Los.............. 0.10\r\n"
                    + "BEP Test.................... -5\r\n"
                    + "Local Rtrn Count............ 00\r\n"
                    + "Remote Rtrn Count........... 00";
            var diagnosticControls = new TelemetryDiagnosticControls(new TelemetryClient());
            //act
            diagnosticControls.SendMessage();
            //assert
            Assert.AreEqual(diagnosticControls.DiagnosticInfo, message);
        }
    }
}
