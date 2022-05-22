using System.Collections.Generic;
using System.Net.Sockets;

namespace CommLink
{
    public class StateObject
    {
        public Analyzer analyzer { get; set; }
        public Socket workSocket = null;
        public const int BUFFER_SIZE = 1024;
        public byte[] buffer = new byte[BUFFER_SIZE];
        public string sb;
        public List<AnalyzerExam> listAnalyzerExams { get; set; }
        //public StringBuilder fileLogStringB = new StringBuilder();
        //public StringBuilder displayLogStringB = new StringBuilder();

        public int index { get; set; }
        public char START_OF_BLOCK = (char)0x0B;
        public char END_OF_BLOCK = (char)0x1C;
        public char CARRIAGE_RETURN = (char)13;
        public int MESSAGE_CONTROL_ID_LOCATION = 9;
        public char FIELD_DELIMITER = '|';
        public char STX = (char)2;
        public char ACK = (char)6;
    }
}
