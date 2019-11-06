using System.Web.Http;
using Middleware.Models;
using MiddlewareBLL.LogTrace;
using MiddlewareBLL.LogTrace.Models;
using Newtonsoft.Json;

namespace Middleware.Controllers
{
    public class LogTraceController : ApiController
    {
        [Route("api/AddLogTrace")]
        [HttpPost]
        public string AddLogTrace(LogTrace Trace)
        {
            //Run data validation
            string ReturnErr = LogTraceBLL.getInstance().Validate(JsonConvert.DeserializeObject<LogTraceBLLModel>(JsonConvert.SerializeObject(Trace)));
            if (ReturnErr != "") { return ReturnErr; }

            //Execute Insert Request
            string ReturnVal = LogTraceBLL.getInstance().Create(JsonConvert.DeserializeObject<LogTraceBLLModel>(JsonConvert.SerializeObject(Trace)));
            return ReturnVal;
        }
    }
}
