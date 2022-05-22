using System;
using System.Globalization;
using NHapi.Base.Model;
using NHapi.Model.V23.Message;
using NHapi.Base.Util;

namespace CommLink
{
    class ACKMessageBuilder
    {
        private ACK ackMessage;

        public ACK Build(IMessage incomingMessage) // MSH, MSA, ERR
        {
            var currentDateTimeString = GetCurrentTimeStamp();
            var ControlID = GetSequenceNumber(incomingMessage);

            if (string.IsNullOrEmpty(incomingMessage.ToString()))
                throw new ApplicationException("Invalid HL7 message for parsing operation. Please check your inputs");

            ackMessage = new ACK();
            createMsh(currentDateTimeString, ControlID);
            createMsa(ControlID);
            return ackMessage;
        }
        private void createMsh(string currentDateTimeString, string controlID)
        {
            var mshSegment = ackMessage.MSH;
            mshSegment.FieldSeparator.Value = "|";
            mshSegment.EncodingCharacters.Value = "^~\\&";
            mshSegment.SendingApplication.NamespaceID.Value = "CommLink";
            mshSegment.SendingFacility.NamespaceID.Value = "Rivosana";
            mshSegment.DateTimeOfMessage.TimeOfAnEvent.Value = currentDateTimeString;
            mshSegment.MessageControlID.Value = controlID;
            mshSegment.MessageType.MessageType.Value = "ACK";
            mshSegment.MessageType.TriggerEvent.Value = "R01";
            mshSegment.VersionID.Value = "2.3.1";
            mshSegment.ProcessingID.ProcessingID.Value = "P";
            mshSegment.CharacterSet.Value = "UNICODE";
        }

        private void createMsa(string controlID)
        {
            var msaSegment = ackMessage.MSA;
            msaSegment.AcknowledgementCode.Value = "AA";
            msaSegment.MessageControlID.Value = controlID;
        }
        private void createErr()
        {

        }
        private static string GetCurrentTimeStamp()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss", CultureInfo.InvariantCulture);
        }
        private static string GetSequenceNumber(IMessage msg)
        {
            Terser terser = new Terser(msg);

            string controlID = terser.Get("MSH-10"); // some arbitrary prefix for the facility
            return controlID;
        }
    }
}
