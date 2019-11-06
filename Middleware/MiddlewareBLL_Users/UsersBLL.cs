using MiddlewareDAL.Users.Models;
using MiddlewareDAL.Users;
using MiddlewareBLL.Users.Models;
using Newtonsoft.Json;

namespace MiddlewareBLL.Users
{
    public class UsersBLL
    {
        static UsersBLL Users_Ref = null;

        public static UsersBLL getInstance()
        {
            if (Users_Ref == null)
            {
                Users_Ref = new UsersBLL();
                return Users_Ref;
            }

            else
            {
                return Users_Ref;
            }

        }

        public string Validate(UsersBLLModel UserInfo)
        {
            UserInfoDAL UDAL = new UserInfoDAL();
            string ReturnVal = UDAL.Validate(JsonConvert.DeserializeObject<UsersDALModel>(JsonConvert.SerializeObject(UserInfo)));
            return ReturnVal;
        }

        public string ValidateKey(UsersBLLModel UserInfo)
        {
            UserInfoDAL UDAL = new UserInfoDAL();
            string ReturnVal = UDAL.ValidateKey(JsonConvert.DeserializeObject<UsersDALModel>(JsonConvert.SerializeObject(UserInfo)));
            return ReturnVal;
        }

        public string Create(UsersBLLModel UserInfo)
        {
            UserInfoDAL UDAL = new UserInfoDAL();
            string ReturnVal = UDAL.Create(JsonConvert.DeserializeObject<UsersDALModel>(JsonConvert.SerializeObject(UserInfo)));
            return ReturnVal;
        }

        public string Retrieve(UsersBLLModel UserInfo)
        {
            UserInfoDAL UDAL = new UserInfoDAL();
            string ReturnVal = UDAL.Retrieve(JsonConvert.DeserializeObject<UsersDALModel>(JsonConvert.SerializeObject(UserInfo)));
            return ReturnVal;
        }

        public string Update(UsersBLLModel UserInfo)
        {
            UserInfoDAL UDAL = new UserInfoDAL();
            string ReturnVal = UDAL.Update(JsonConvert.DeserializeObject<UsersDALModel>(JsonConvert.SerializeObject(UserInfo)));
            return ReturnVal;
        }

        public string Delete(UsersBLLModel UserInfo)
        {
            UserInfoDAL UDAL = new UserInfoDAL();
            string ReturnVal = UDAL.Delete(JsonConvert.DeserializeObject<UsersDALModel>(JsonConvert.SerializeObject(UserInfo)));
            return ReturnVal;
        }
    }
}