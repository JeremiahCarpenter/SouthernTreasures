using System.Web.Http;
using Middleware.Models;
using MiddlewareBLL.Users;
using MiddlewareBLL.Users.Models;
using Newtonsoft.Json;

namespace Middleware.Controllers
{
    public class UsersController : ApiController
    {
        [Route("api/AddUser")]
        [HttpPost]
        public string AddUser(Users UserInfo)
        {
            //Run data validation
            string ReturnErr = UsersBLL.getInstance().Validate(JsonConvert.DeserializeObject<UsersBLLModel>(JsonConvert.SerializeObject(UserInfo)));
            if(ReturnErr != "") { return ReturnErr; }

            //Execute Insert Request
            string ReturnVal = UsersBLL.getInstance().Create(JsonConvert.DeserializeObject<UsersBLLModel>(JsonConvert.SerializeObject(UserInfo)));
            return ReturnVal;
        }

        [Route("api/RetrieveUser")]
        [HttpPost]
        public string RetrieveUser(Users UserInfo)
        {
            //User Retrieve Request
            string ReturnVal = UsersBLL.getInstance().Retrieve(JsonConvert.DeserializeObject<UsersBLLModel>(JsonConvert.SerializeObject(UserInfo)));
            return ReturnVal;
        }

        [Route("api/UpdateUser")]
        [HttpPost]
        public string UpdateUser(Users UserInfo)
        {
            //Run data validation
            string ReturnErr = UsersBLL.getInstance().ValidateKey(JsonConvert.DeserializeObject<UsersBLLModel>(JsonConvert.SerializeObject(UserInfo)));
            if (ReturnErr != "") { return ReturnErr; }

            //Execute Update Request
            string ReturnVal = UsersBLL.getInstance().Update(JsonConvert.DeserializeObject<UsersBLLModel>(JsonConvert.SerializeObject(UserInfo)));
            return ReturnVal;
        }

        [Route("api/DeleteUser")]
        [HttpPost]
        public string DeleteUser(Users UserInfo)
        {
            //Run data validation
            string ReturnErr = UsersBLL.getInstance().ValidateKey(JsonConvert.DeserializeObject<UsersBLLModel>(JsonConvert.SerializeObject(UserInfo)));
            if (ReturnErr != "") { return ReturnErr; }

            //Execute Delete Request
            string ReturnVal = UsersBLL.getInstance().Delete(JsonConvert.DeserializeObject<UsersBLLModel>(JsonConvert.SerializeObject(UserInfo)));
            return ReturnVal;
        }
    }
}
