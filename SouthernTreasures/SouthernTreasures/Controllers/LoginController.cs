using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using SouthernTreasures.Users.Model;
using SouthernTreasuresBLL.Users;
using SouthernTreasuresBLL.Users.Model;

namespace SouthernTreasures.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoginPage()
        {
            return View();
        }

        public ActionResult RegisterPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProcessLogin(UsersModel FormData)
        {
            UsersBLLModel UserTmp = new UsersBLLModel();
            UserTmp = UserInfoBLL.getInstance().Retrieve(JsonConvert.DeserializeObject<UsersBLLModel>(JsonConvert.SerializeObject(FormData)));

            return View();
        }
    }
}