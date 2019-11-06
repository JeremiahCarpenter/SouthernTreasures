namespace SouthernTreasuresBLL.Products.Model
{
    public class ProductsBLLModel
    {
        private int _ID;
        private int _UserID_Nbr;
        private int _CategoryID_Nbr;
        private string _Name_Txt;
        private string _Description_Txt;
        private decimal _MinPrice_Dec;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public int UserID_Nbr
        {
            get { return _UserID_Nbr; }
            set { _UserID_Nbr = value; }
        }

        public int CategoryID_Nbr
        {
            get { return _CategoryID_Nbr; }
            set { _CategoryID_Nbr = value; }
        }

        public string Name_Txt
        {
            get { return _Name_Txt; }
            set { _Name_Txt = value; }
        }

        public string Description_Txt
        {
            get { return _Description_Txt; }
            set { _Description_Txt = value; }
        }

        public decimal MinPrice_Dec
        {
            get { return _MinPrice_Dec; }
            set { _MinPrice_Dec = value; }
        }

        public ProductsBLLModel(int ID, int UserID_Nbr, int CategoryID_Nbr, string Name_Txt, string Description_Txt, decimal MinPrice_Dec)
        {
            this.ID = ID;
            this.UserID_Nbr = UserID_Nbr;
            this.CategoryID_Nbr = CategoryID_Nbr;
            this.Name_Txt = Name_Txt;
            this.Description_Txt = Description_Txt;
            this.MinPrice_Dec = MinPrice_Dec;
        }

        public ProductsBLLModel()
        {

        }
    }
}
