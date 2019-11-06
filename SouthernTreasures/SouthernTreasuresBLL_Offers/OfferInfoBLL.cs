using SouthernTreasuresDAL.Offers;
using SouthernTreasuresDAL.Offers.Model;
using SouthernTreasuresBLL.Offers.Model;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SouthernTreasuresBLL.Offers
{
    public class OfferInfoBLL
    {
        static OfferInfoBLL Offer_Ref = null;

        public static OfferInfoBLL getInstance()
        {
            if (Offer_Ref == null)
            {
                Offer_Ref = new OfferInfoBLL();
                return Offer_Ref;
            }

            else
            {
                return Offer_Ref;
            }

        }

        public string Validate(OffersBLLModel OfferInfo)
        {
            OfferInfoDAL UDAL = new OfferInfoDAL();
            string ReturnVal = UDAL.Validate(JsonConvert.DeserializeObject<OffersDALModel>(JsonConvert.SerializeObject(OfferInfo)));
            return ReturnVal;
        }

        public string ValidateKey(OffersBLLModel OfferInfo)
        {
            OfferInfoDAL UDAL = new OfferInfoDAL();
            string ReturnVal = UDAL.ValidateKey(JsonConvert.DeserializeObject<OffersDALModel>(JsonConvert.SerializeObject(OfferInfo)));
            return ReturnVal;
        }

        public string Create(OffersBLLModel OfferInfo)
        {
            OfferInfoDAL UDAL = new OfferInfoDAL();
            string ReturnVal = UDAL.Create(JsonConvert.DeserializeObject<OffersDALModel>(JsonConvert.SerializeObject(OfferInfo)));
            return ReturnVal;
        }

        public List<OffersBLLModel> Retrieve()
        {
            OfferInfoDAL UDAL = new OfferInfoDAL();
            List<OffersBLLModel> RetOfferInfo = JsonConvert.DeserializeObject<List<OffersBLLModel>>(JsonConvert.SerializeObject(UDAL.Retrieve()));
            return RetOfferInfo;
        }

        public OffersBLLModel RetrieveByID(int ID)
        {
            OfferInfoDAL UDAL = new OfferInfoDAL();
            OffersBLLModel RetOfferInfo = JsonConvert.DeserializeObject<OffersBLLModel>(JsonConvert.SerializeObject(UDAL.RetrieveByID(ID)));
            return RetOfferInfo;
        }

        public string Update(OffersBLLModel OfferInfo)
        {
            OfferInfoDAL UDAL = new OfferInfoDAL();
            string ReturnVal = UDAL.Update(JsonConvert.DeserializeObject<OffersDALModel>(JsonConvert.SerializeObject(OfferInfo)));
            return ReturnVal;
        }

        public string Delete(int ID)
        {
            OfferInfoDAL UDAL = new OfferInfoDAL();
            string ReturnVal = UDAL.Delete(ID);
            return ReturnVal;
        }
    }
}
