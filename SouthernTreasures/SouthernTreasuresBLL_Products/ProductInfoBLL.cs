using SouthernTreasuresDAL.Products;
using SouthernTreasuresDAL.Products.Model;
using SouthernTreasuresBLL.Products.Model;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SouthernTreasuresBLL.Products
{
    public class ProductInfoBLL
    {
        static ProductInfoBLL Product_Ref = null;

        public static ProductInfoBLL getInstance()
        {
            if (Product_Ref == null)
            {
                Product_Ref = new ProductInfoBLL();
                return Product_Ref;
            }

            else
            {
                return Product_Ref;
            }

        }

        public string Validate(ProductsBLLModel ProductInfo)
        {
            ProductInfoDAL UDAL = new ProductInfoDAL();
            string ReturnVal = UDAL.Validate(JsonConvert.DeserializeObject<ProductsDALModel>(JsonConvert.SerializeObject(ProductInfo)));
            return ReturnVal;
        }

        public string ValidateKey(ProductsBLLModel ProductInfo)
        {
            ProductInfoDAL UDAL = new ProductInfoDAL();
            string ReturnVal = UDAL.ValidateKey(JsonConvert.DeserializeObject<ProductsDALModel>(JsonConvert.SerializeObject(ProductInfo)));
            return ReturnVal;
        }

        public string Create(ProductsBLLModel ProductInfo)
        {
            ProductInfoDAL UDAL = new ProductInfoDAL();
            string ReturnVal = UDAL.Create(JsonConvert.DeserializeObject<ProductsDALModel>(JsonConvert.SerializeObject(ProductInfo)));
            return ReturnVal;
        }

        public List<ProductsBLLModel> Retrieve()
        {
            ProductInfoDAL UDAL = new ProductInfoDAL();
            List<ProductsBLLModel> RetProductInfo = JsonConvert.DeserializeObject<List<ProductsBLLModel>>(JsonConvert.SerializeObject(UDAL.Retrieve()));
            return RetProductInfo;
        }

        public ProductsBLLModel RetrieveByID(int ID)
        {
            ProductInfoDAL UDAL = new ProductInfoDAL();
            ProductsBLLModel RetProductInfo = JsonConvert.DeserializeObject<ProductsBLLModel>(JsonConvert.SerializeObject(UDAL.RetrieveByID(ID)));
            return RetProductInfo;
        }

        public string Update(ProductsBLLModel ProductInfo)
        {
            ProductInfoDAL UDAL = new ProductInfoDAL();
            string ReturnVal = UDAL.Update(JsonConvert.DeserializeObject<ProductsDALModel>(JsonConvert.SerializeObject(ProductInfo)));
            return ReturnVal;
        }

        public string Delete(int ID)
        {
            ProductInfoDAL UDAL = new ProductInfoDAL();
            string ReturnVal = UDAL.Delete(ID);
            return ReturnVal;
        }
    }
}
