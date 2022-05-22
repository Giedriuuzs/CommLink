using System;
using NHapi.Base.Model;

namespace CommLink
{
    public class MessageFactory
    {
        public static IMessage CreateMessage(string messageType, IMessage incomingMessage)
        {
            //This patterns enables you to build other message types 
            if (messageType.Equals("ACK"))
            {
                return new ACKMessageBuilder().Build(incomingMessage);
            }

            throw new ArgumentException($"'{messageType}' is not available yet. Needs to be added.");
        }
    }
}
