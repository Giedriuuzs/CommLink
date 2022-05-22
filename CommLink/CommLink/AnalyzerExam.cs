namespace CommLink
{
    public class AnalyzerExam
    {
        public int analyzerExamID { get; set; }
        public int analyzerID { get; set; }
        public string ISExamCode { get; set; }
        public string ISAnalystCode { get; set; }
        public string AnalyzerExamCode { get; set; }
        public bool SendToAnalyzer { get; set; }
        public bool Active { get; set; }

        public AnalyzerExam(int analyzerExamID, int analyzerID, string iSExamCode, string iSAnalystCode, string analyzerExamCode, bool sendToAnalyzer, bool active)
        {
            this.analyzerExamID = analyzerExamID;
            this.analyzerID = analyzerID;
            ISExamCode = iSExamCode;
            ISAnalystCode = iSAnalystCode;
            AnalyzerExamCode = analyzerExamCode;
            SendToAnalyzer = sendToAnalyzer;
            Active = active;
        }
        public AnalyzerExam()
        { }

    }
}
