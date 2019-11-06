using System;
using System.Runtime.Serialization;

namespace MiddlewareBLL.Users.Models
{
    [DataContract]
    public class UsersBLLModel
    {
        private int _ID; 
        private string _Name_Txt;
        private string _Password_Txt;
        private string _Email_Txt;
        private decimal _Money_Dec;

        [DataMember(Name = "ID")]
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        [DataMember(Name = "Name_Txt")]
        public string Name_Txt
        {
            get { return _Name_Txt; }
            set { _Name_Txt = value; }
        }

        [DataMember(Name = "Password_Txt")]
        public string Password_Txt
        {
            get { return _Password_Txt; }
            set { _Password_Txt = value; }
        }

        [DataMember(Name = "Email_Txt")]
        public string Email_Txt
        {
            get { return _Email_Txt; }
            set { _Email_Txt = value; }
        }

        [DataMember(Name = "Money_Dec")]
        public Decimal Money_Dec
        {
            get { return _Money_Dec; }
            set { _Money_Dec = value; }
        }
    }
}