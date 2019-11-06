namespace MiddlewareDAL.LogTrace.Models
{
    public class LogTraceDALModel
    {
        private string _AppName_Txt;
        private string _Message_Txt;
        private string _UserName_Txt;

        public string AppName_Txt
        {
            get { return _AppName_Txt; }
            set { _AppName_Txt = value; }
        }

        public string Message_Txt
        {
            get { return _Message_Txt; }
            set { _Message_Txt = value; }
        }

        public string UserName_Txt
        {
            get { return _UserName_Txt; }
            set { _UserName_Txt = value; }
        }
    }
}