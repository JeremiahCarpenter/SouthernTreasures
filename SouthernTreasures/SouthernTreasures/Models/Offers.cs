using System;
namespace SouthernTreasures.Offers.Model
{
    public class OffersModel
    {
        private int _ID;
        private int _UserID_Nbr;
        private int _ProductID_Nbr;
        private decimal _Price_Dec;
        private DateTime _Submitted_DtTM;

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

        public int ProductID_Nbr
        {
            get { return _ProductID_Nbr; }
            set { _ProductID_Nbr = value; }
        }

        public decimal Price_Dec
        {
            get { return _Price_Dec; }
            set { _Price_Dec = value; }
        }

        public DateTime Submitted_DtTM
        {
            get { return _Submitted_DtTM; }
            set { _Submitted_DtTM = value; }
        }

        public OffersModel(int ID, int UserID_Nbr, int ProductID_Nbr, decimal Price_Dec, DateTime Submitted_DtTm)
        {
            this.ID = ID;
            this.UserID_Nbr = UserID_Nbr;
            this.ProductID_Nbr = ProductID_Nbr;
            this.Price_Dec = Price_Dec;
            this.Submitted_DtTM = Submitted_DtTM;
        }

        public OffersModel()
        {

        }
    }
}
