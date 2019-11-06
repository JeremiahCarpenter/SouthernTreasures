using SouthernTreasuresDAL.Categories;
using SouthernTreasuresDAL.Categories.Model;
using SouthernTreasuresBLL.Categories.Model;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SouthernTreasuresBLL.Categories
{
    public class CategoryInfoBLL
    {
        static CategoryInfoBLL Category_Ref = null;

        public static CategoryInfoBLL getInstance()
        {
            if (Category_Ref == null)
            {
                Category_Ref = new CategoryInfoBLL();
                return Category_Ref;
            }

            else
            {
                return Category_Ref;
            }

        }

        public List<CategoriesBLLModel> Retrieve()
        {
            CategoryInfoDAL UDAL = new CategoryInfoDAL();
            List<CategoriesBLLModel> RetCategoryInfo = JsonConvert.DeserializeObject<List<CategoriesBLLModel>>(JsonConvert.SerializeObject(UDAL.Retrieve()));
            return RetCategoryInfo;
        }
    }
}
