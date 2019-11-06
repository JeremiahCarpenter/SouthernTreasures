using System;
using SouthernTreasuresDAL.Users.Model;
using System.Net.Http;
using System.Configuration;
using Newtonsoft.Json;
using System.Web.Http;
using System.IO;
using System.Text;

namespace SouthernTreasuresDAL.Users
{
    public class UserInfoDAL : ApiController
    {
        private UriBuilder RetrieveUserPath = new UriBuilder(ConfigurationManager.AppSettings["MiddlewareRetrieveUser"]);
        private UriBuilder CreateUserPath = new UriBuilder(ConfigurationManager.AppSettings["MiddlewareCreateUser"]);
        private UriBuilder UpdateUserPath = new UriBuilder(ConfigurationManager.AppSettings["MiddlewareUpdateUser"]);
        private UriBuilder DeleteUserPath = new UriBuilder(ConfigurationManager.AppSettings["MiddlewareDeleteUser"]);

        public string Validate(UsersDALModel UserInfo)
        {
            //Ensure UserInfo isn't null
            if (UserInfo == null)
            {
                return "User Object is empty.";
            }

            //Check for blank Name
            if (UserInfo.Name_Txt == "")
            {
                return "The User Name is blank in the Users Insert request.";
            }

            //Check for blank Password
            if (UserInfo.Password_Txt == "")
            {
                return "The User Password is blank in the Users Insert request.";
            }

            //Check for blank Email
            if (UserInfo.Email_Txt == "")
            {
                return "The User Email is blank in the Users Insert request.";
            }

            //Check for empty balance
            if (UserInfo.Money_Dec <= 0)
            {
                return "The User Balance is blank in the Users Insert request.";
            }

            return "";
        }

        public string ValidateKey(UsersDALModel UserInfo)
        {
            //Ensure UserInfo isn't null
            if (UserInfo == null)
            {
                return "User Object is empty.";
            }

            //Ensure a key is provided
            if (UserInfo.ID < 1)
            {
                return "The Primary Key was not provided for the User Update.";
            }

            return "";
        }

        public string Create(UsersDALModel UserInfo)
        {
            //Return string
            String RetValue = "";

            try
            {
                //Build arguments
                var RequestInfo = JsonConvert.SerializeObject(UserInfo);

                //Call Service and Return Result
                HttpClient client = new HttpClient();
                var result = client.PostAsync(CreateUserPath.Uri, new StringContent(content: RequestInfo, encoding: Encoding.UTF8, mediaType: "application/json")).Result;
                using (StreamReader sr = new StreamReader(result.Content.ReadAsStreamAsync().Result))
                {
                    RetValue = sr.ReadToEnd();
                }

                //Cleanup
                client.Dispose();
            }

            catch (Exception ex)
            {
                //REPLACE WITH MIDDLEWARE LOG WRITE.
                throw new Exception("Unable to access the Middleware database: " + ex);
            }

            return RetValue;
        }

        public UsersDALModel RetrieveByNameAndPass(UsersDALModel UserInfo)
        {
            UsersDALModel RetUserInfo = new UsersDALModel();

            try
            {
                //Build arguments
                var RequestInfo = JsonConvert.SerializeObject(UserInfo);

                //Call Service and Return Model
                HttpClient client = new HttpClient();
                var result = client.PostAsync(RetrieveUserPath.Uri, new StringContent(content: RequestInfo, encoding: Encoding.UTF8, mediaType: "application/json")).Result;
                using (StreamReader sr = new StreamReader(result.Content.ReadAsStreamAsync().Result))
                {
                    string ReturnValTmp = sr.ReadToEnd().Replace("\\", string.Empty);
                    string ReturnVal = ReturnValTmp.Substring(1, ReturnValTmp.Length - 2);

                    if(ReturnVal.Contains("ID") == true)
                    {
                        RetUserInfo = JsonConvert.DeserializeObject<UsersDALModel>(ReturnVal);
                    }
                }

                //Cleanup
                client.Dispose();
            }

            catch (Exception ex)
            {
                //REPLACE WITH MIDDLEWARE LOG WRITE.
                throw new Exception("Unable to access the Middleware database: " + ex);
            }

            return RetUserInfo;
        }

        public string Update(UsersDALModel UserInfo)
        {
            //Return string
            String RetValue = "";

            try
            {
                //Build arguments
                var RequestInfo = JsonConvert.SerializeObject(UserInfo);

                //Call Service and Return Result
                HttpClient client = new HttpClient();
                var result = client.PostAsync(UpdateUserPath.Uri, new StringContent(content: RequestInfo, encoding: Encoding.UTF8, mediaType: "application/json")).Result;
                using (StreamReader sr = new StreamReader(result.Content.ReadAsStreamAsync().Result))
                {
                    RetValue = sr.ReadToEnd();
                }

                //Cleanup
                client.Dispose();
            }

            catch (Exception ex)
            {
                //REPLACE WITH MIDDLEWARE LOG WRITE.
                throw new Exception("Unable to access the Middleware database: " + ex);
            }

            return RetValue;
        }

        public string Delete(int ID)
        {
            //Return string
            String RetValue = "";
            
            try
            {
                //Build arguments
                string RequestInfo = "ID:" + ID;

                //Call Service and Return Result
                HttpClient client = new HttpClient();
                var result = client.PostAsync(DeleteUserPath.Uri, new StringContent(content: RequestInfo, encoding: Encoding.UTF8, mediaType: "application/json")).Result;
                using (StreamReader sr = new StreamReader(result.Content.ReadAsStreamAsync().Result))
                {
                    RetValue = sr.ReadToEnd();
                }

                //Cleanup
                client.Dispose();
            }

            catch (Exception ex)
            {
                //REPLACE WITH MIDDLEWARE LOG WRITE.
                throw new Exception("Unable to access the Middleware database: " + ex);
            }

            return RetValue;
        }
    }
}
