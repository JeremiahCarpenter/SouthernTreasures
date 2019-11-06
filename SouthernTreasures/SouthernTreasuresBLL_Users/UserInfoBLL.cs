using SouthernTreasuresDAL.Users;
using SouthernTreasuresDAL.Users.Model;
using SouthernTreasuresBLL.Users.Model;
using Newtonsoft.Json;

namespace SouthernTreasuresBLL.Users
{
    public class UserInfoBLL
    {
        static UserInfoBLL Users_Ref = null;

        public static UserInfoBLL getInstance()
        {
            if (Users_Ref == null)
            {
                Users_Ref = new UserInfoBLL();
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

        public UsersBLLModel Retrieve(UsersBLLModel UserInfo)
        {
            UserInfoDAL UDAL = new UserInfoDAL();
            UsersBLLModel RetUserInfo = JsonConvert.DeserializeObject<UsersBLLModel>(JsonConvert.SerializeObject(UDAL.RetrieveByNameAndPass(JsonConvert.DeserializeObject<UsersDALModel>(JsonConvert.SerializeObject(UserInfo)))));               
            return RetUserInfo;
        }

        public string Update(UsersBLLModel UserInfo)
        {
            UserInfoDAL UDAL = new UserInfoDAL();
            string ReturnVal = UDAL.Update(JsonConvert.DeserializeObject<UsersDALModel>(JsonConvert.SerializeObject(UserInfo)));
            return ReturnVal;
        }

        public string Delete(int ID)
        {
            UserInfoDAL UDAL = new UserInfoDAL();
            string ReturnVal = UDAL.Delete(ID);
            return ReturnVal;
        }
    }
}
