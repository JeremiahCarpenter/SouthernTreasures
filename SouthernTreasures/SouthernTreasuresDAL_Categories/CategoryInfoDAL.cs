using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using SouthernTreasuresDAL.Connection;
using SouthernTreasuresDAL.Categories.Model;

namespace SouthernTreasuresDAL.Categories
{
    public class CategoryInfoDAL
    {
        public string RetrieveSQL = "SELECT [ID], [Name_Txt] FROM Categories";
        public DBConnectionStr SQLDB = new DBConnectionStr();

        public List<CategoriesDALModel> Retrieve()
        {
            List<CategoriesDALModel> CategoryList = new List<CategoriesDALModel>();
            using (SQLDB.SQLConnection)
            {
                try
                {
                    SQLDB.SQLConnection.Open();

                    //Retrieve
                    using (SqlCommand Cmd = new SqlCommand(RetrieveSQL, SQLDB.SQLConnection))
                    {
                        //Retrieve data
                        using (SqlDataReader InpReader = Cmd.ExecuteReader())
                        {
                            while (InpReader.Read())
                            {
                                CategoryList.Add(new CategoriesDALModel(Convert.ToInt32(InpReader["ID"]), InpReader["Name_Txt"].ToString()));
                            }
                        }

                        //Validate if valid
                        if (CategoryList.Count == 0)
                        {
                            //REPLACE WITH MIDDLEWARE LOG WRITE.
                            throw new Exception ("Nothing returned from the Categories table.");
                        }
                    }
                }

                catch (Exception ex)
                {
                    //REPLACE WITH MIDDLEWARE LOG WRITE.
                    throw new Exception("Unable to access the SouthernTreasures database: " + ex);
                }
            }

            return CategoryList;
        }
    }
}
