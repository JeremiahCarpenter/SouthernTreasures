namespace SouthernTreasuresBLL.Users.Model
{
    public class UsersBLLModel
    {
        private int _ID;
        private string _Name_Txt;
        private string _Password_Txt;
        private string _Email_Txt;
        private decimal _Money_Dec;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string Name_Txt
        {
            get { return _Name_Txt; }
            set { _Name_Txt = value; }
        }

        public string Password_Txt
        {
            get { return _Password_Txt; }
            set { _Password_Txt = value; }
        }

        public string Email_Txt
        {
            get { return _Email_Txt; }
            set { _Email_Txt = value; }
        }

        public decimal Money_Dec
        {
            get { return _Money_Dec; }
            set { _Money_Dec = value; }
        }

        public UsersBLLModel(int ID, string Name_Txt, string Password_Txt, string Email_Txt, decimal Money_Dec)
        {
            this.ID = ID;
            this.Name_Txt = Name_Txt;
            this.Password_Txt = Password_Txt;
            this.Email_Txt = Email_Txt;
            this.Money_Dec = Money_Dec;
        }

        public UsersBLLModel()
        {

        }
    }
}
