using MiddlewareDAL.LogTrace.Models;
using MiddlewareDAL.LogTrace;
using MiddlewareBLL.LogTrace.Models;
using Newtonsoft.Json;

namespace MiddlewareBLL.LogTrace
{
    public class LogTraceBLL
    {
        static LogTraceBLL LogTrace_Ref = null;

        public static LogTraceBLL getInstance()
        {
            if (LogTrace_Ref == null)
            {
                LogTrace_Ref = new LogTraceBLL();
                return LogTrace_Ref;
            }

            else
            {
                return LogTrace_Ref;
            }

        }

        public string Validate(LogTraceBLLModel Trace)
        {
            LogTraceDAL LTDAL = new LogTraceDAL();
            string ReturnVal = LTDAL.Validate(JsonConvert.DeserializeObject<LogTraceDALModel>(JsonConvert.SerializeObject(Trace)));
            return ReturnVal;
        }

        public string Create(LogTraceBLLModel Trace)
        {
            LogTraceDAL LTDAL = new LogTraceDAL();
            string ReturnVal = LTDAL.Create(JsonConvert.DeserializeObject<LogTraceDALModel>(JsonConvert.SerializeObject(Trace)));
            return ReturnVal;
        }
    }
}