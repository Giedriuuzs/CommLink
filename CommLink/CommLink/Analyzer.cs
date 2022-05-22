namespace CommLink
{
    public class Analyzer
    {
        public int analyzerID { get; set; }
        public string analyzerCode { get; set; }
        public string analyzerProtocolName { get; set; }
        public string analyzerType { get; set; }
        public string analyzerTCPIP { get; set; }
        public string analyzerPort { get; set; }
        public string ISCode { get; set; }
        public string ISProtocolName { get; set; }
        public string ISType { get; set; }
        public string ISTCPIP { get; set; }
        public string ISPort { get; set; }
        public bool visible { get; set; }
        public bool active { get; set; }
        public bool listening { get; set; }

        public Analyzer(int analyzerID, string analyzerCode, string analyzerProtocolName, string analyzerType, string analyzerTCPIP, string analyzerPort, string iSCode, string iSProtocolName, string iSType, string iSTCPIP, string iSPort, bool visible, bool active, bool listening)
        {
            this.analyzerID = analyzerID;
            this.analyzerCode = analyzerCode;
            this.analyzerProtocolName = analyzerProtocolName;
            this.analyzerType = analyzerType;
            this.analyzerTCPIP = analyzerTCPIP;
            this.analyzerPort = analyzerPort;
            ISCode = iSCode;
            ISProtocolName = iSProtocolName;
            ISType = iSType;
            ISTCPIP = iSTCPIP;
            ISPort = iSPort;
            this.visible = visible;
            this.active = active;
            this.listening = listening;
        }

        public Analyzer()
        {
        }
    }
}
