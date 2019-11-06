using System;
using LoggingFramework.Model;
using System.Net.Http;
using System.Configuration;
using System.IO;

namespace LoggingFramework
{
    public class LoggingLogic
    {
        private UriBuilder LoggingPath = new UriBuilder(ConfigurationManager.AppSettings["MiddlewareLogging"]);

        public string CreateNewLogEntry(Logging LogInfo)
        {
            //Return string
            String RetValue = "";

            //Build arguments
            LoggingPath.Query = "AppName_Txt=" + LogInfo.AppName_Txt + "&" + "Message_Txt=" + LogInfo.Message_Txt + "&" + "UserName_Txt=" + LogInfo.UserName_Txt;

            //Call Service and Return Result
            HttpClient client = new HttpClient();
            var result = client.GetAsync(LoggingPath.Uri).Result;
            using (StreamReader sr = new StreamReader(result.Content.ReadAsStreamAsync().Result))
            {
                RetValue = sr.ReadToEnd();
            }

            //Cleanup
            client.Dispose();

            return RetValue;
        }
    }
}
