namespace SouthernTreasures.Categories.Model
{
    public class CategoriesModel
    {
        private int _ID;
        private string _Name_Txt;

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

        public CategoriesModel(int ID, string Name_Txt)
        {
            this.ID = ID;
            this.Name_Txt = Name_Txt;
        }

    }
}
