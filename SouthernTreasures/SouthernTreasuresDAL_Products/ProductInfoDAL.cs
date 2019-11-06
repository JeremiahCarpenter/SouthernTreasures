using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using SouthernTreasuresDAL.Connection;
using SouthernTreasuresDAL.Products.Model;

namespace SouthernTreasuresDAL.Products
{
    public class ProductInfoDAL
    {
        public string InsertSQL = "INSERT INTO Products ([UserID_Nbr], [CategoryID_Nbr], [Name_Txt], [Description_Txt], [MinPrice_Dec]) OUTPUT Inserted.ID values(@UserID, @CategoryID, @Name, @Description, @MinPrice)";
        public string RetrieveSQL = "SELECT [ID], [UserID_Nbr], [CategoryID_Nbr], [Name_Txt], [Description_Txt], [MinPrice_Dec] FROM Products";
        public string RetrieveByIDSQL = "SELECT [ID], [UserID_Nbr], [CategoryID_Nbr], [Name_Txt], [Description_Txt], [MinPrice_Dec] FROM Products WHERE [ID] = @ID;";
        public string UpdateSQL = "UPDATE Products SET [UserID_Nbr] = @UserID, [CategoryID_Nbr = @CategoryID, [Name_Txt] = @Name, [Description_Txt] = @Description, [MinPrice_Dec] = @MinPrice WHERE [ID] = @ID";
        public string DeleteSQL = "DELETE FROM Products WHERE [ID] = @ID";
        public DBConnectionStr SQLDB = new DBConnectionStr();

        public string Validate(ProductsDALModel ProductInfo)
        {
            //Ensure ProductInfo isn't null
            if (ProductInfo == null)
            {
                return "Offer Object is empty.";
            }

            //Check for blank User ID
            if (ProductInfo.UserID_Nbr == 0)
            {
                return "The Product User ID is blank in the Product Insert request.";
            }

            //Check for blank Category ID
            if (ProductInfo.CategoryID_Nbr == 0)
            {
                return "The Product Category ID is blank in the Product Insert request.";
            }

            //Check for invalid Product Name
            if (ProductInfo.Name_Txt == "")
            {
                return "The Product Name is invalid in the Product Insert request.";
            }

            //Check for invalid Description
            if (ProductInfo.Description_Txt == "")
            {
                return "The Product Description is invalid in the Product Insert request.";
            }

            //Check for invalid Description
            if (ProductInfo.MinPrice_Dec <= 0)
            {
                return "The Product Minimum Price is invalid in the Product Insert request.";
            }

            return "";
        }

        public string ValidateKey(ProductsDALModel ProductInfo)
        {
            //Ensure ProductInfo isn't null
            if (ProductInfo == null)
            {
                return "Product Object is empty.";
            }

            //Ensure a key is provided
            if (ProductInfo.ID < 1)
            {
                return "The Primary Key was not provided for the Product Update.";
            }

            return "";
        }

        public string Create(ProductsDALModel ProductInfo)
        {
            using (SQLDB.SQLConnection)
            {
                try
                {
                    SQLDB.SQLConnection.Open();

                    //Create
                    using (SqlCommand Cmd = new SqlCommand(InsertSQL, SQLDB.SQLConnection))
                    {
                        //Set up Parameters
                        Cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = ProductInfo.UserID_Nbr;
                        Cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = ProductInfo.CategoryID_Nbr;
                        Cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = ProductInfo.Name_Txt;
                        Cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = ProductInfo.Description_Txt;
                        Cmd.Parameters.Add("@MinPrice", SqlDbType.Decimal).Value = ProductInfo.MinPrice_Dec;

                        //Execute and Validate
                        string RetVal = Cmd.ExecuteScalar().ToString();
                        if (RetVal == "0")
                        {
                            //REPLACE WITH MIDDLEWARE LOG WRITE.
                            throw new Exception("Unable to write to the SouthernTreasures Products table.");
                        }

                        else
                        {
                            return RetVal;
                        }
                    }
                }

                catch (Exception ex)
                {
                    //REPLACE WITH MIDDLEWARE LOG WRITE.
                    throw new Exception("Unable to access the SouthernTreasures database: " + ex);
                }
            }
        }

        public List<ProductsDALModel> Retrieve()
        {
            List<ProductsDALModel> ProductsInfo = new List<ProductsDALModel>();
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
                                ProductsInfo.Add(new ProductsDALModel(
                                    Convert.ToInt32(InpReader["ID"]),
                                    Convert.ToInt32(InpReader["UserID_Nbr"]),
                                    Convert.ToInt32(InpReader["CategoryID_Nbr"]),
                                    Convert.ToString(InpReader["Name_Txt"]),
                                    Convert.ToString(InpReader["Description_Txt"]),
                                    Convert.ToDecimal(InpReader["MinPrice_Dec"])
                                    ));
                            }
                        }

                        //Validate if valid
                        if (ProductsInfo.Count == 0)
                        {
                            //REPLACE WITH MIDDLEWARE LOG WRITE.
                            throw new Exception("Nothing found in the SouthernTreasures Products table.");
                        }
                    }
                }

                catch (Exception ex)
                {
                    //REPLACE WITH MIDDLEWARE LOG WRITE.
                    throw new Exception("Unable to access the SouthernTreasures database: " + ex);
                }

                return ProductsInfo;
            }
        }

        public ProductsDALModel RetrieveByID(int ID)
        {
            ProductsDALModel ProductsInfo = new ProductsDALModel();
            using (SQLDB.SQLConnection)
            {
                try
                {
                    SQLDB.SQLConnection.Open();

                    //Retrieve
                    using (SqlCommand Cmd = new SqlCommand(RetrieveByIDSQL, SQLDB.SQLConnection))
                    {
                        //Set up Parameters
                        Cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;

                        //Retrieve data
                        using (SqlDataReader InpReader = Cmd.ExecuteReader())
                        {
                            while (InpReader.Read())
                            {
                                ProductsInfo = new ProductsDALModel(
                                    Convert.ToInt32(InpReader["ID"]),
                                    Convert.ToInt32(InpReader["UserID_Nbr"]),
                                    Convert.ToInt32(InpReader["CategoryID_Nbr"]),
                                    Convert.ToString(InpReader["Name_Txt"]),
                                    Convert.ToString(InpReader["Description_Txt"]),
                                    Convert.ToDecimal(InpReader["MinPrice_Dec"])
                                );
                            }
                        }

                        //Validate if valid
                        if (ProductsInfo.UserID_Nbr == 0)
                        {
                            //REPLACE WITH MIDDLEWARE LOG WRITE.
                            throw new Exception("Nothing found with this ID in the SouthernTreasures Products table.");
                        }
                    }
                }

                catch (Exception ex)
                {
                    //REPLACE WITH MIDDLEWARE LOG WRITE.
                    throw new Exception("Unable to access the SouthernTreasures database: " + ex);
                }

                return ProductsInfo;
            }
        }

        public string Update(ProductsDALModel ProductInfo)
        {
            using (SQLDB.SQLConnection)
            {
                try
                {
                    SQLDB.SQLConnection.Open();

                    //Update
                    using (SqlCommand Cmd = new SqlCommand(UpdateSQL, SQLDB.SQLConnection))
                    {
                        //Set up Parameters
                        Cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ProductInfo.ID;
                        Cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = ProductInfo.UserID_Nbr;
                        Cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = ProductInfo.CategoryID_Nbr;
                        Cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = ProductInfo.Name_Txt;
                        Cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = ProductInfo.Description_Txt;
                        Cmd.Parameters.Add("@MinPrice", SqlDbType.Decimal).Value = ProductInfo.MinPrice_Dec;

                        //Execute and Validate
                        int RetVal = Cmd.ExecuteNonQuery();
                        if (RetVal == 0)
                        {
                            //REPLACE WITH MIDDLEWARE LOG WRITE.
                            throw new Exception("Unable to update the SouthernTreasures Products table.");
                        }

                        else
                        {
                            return RetVal.ToString();
                        }
                    }
                }

                catch (Exception ex)
                {
                    //REPLACE WITH MIDDLEWARE LOG WRITE.
                    throw new Exception("Unable to access the SouthernTreasures database: " + ex);
                }
            }
        }

        public string Delete(int ID)
        {
            using (SQLDB.SQLConnection)
            {
                try
                {
                    SQLDB.SQLConnection.Open();

                    //Delete
                    using (SqlCommand Cmd = new SqlCommand(DeleteSQL, SQLDB.SQLConnection))
                    {
                        //Set up Parameters
                        Cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;

                        //Execute and Validate
                        int RetVal = Cmd.ExecuteNonQuery();
                        if (RetVal == 0)
                        {
                            //REPLACE WITH MIDDLEWARE LOG WRITE.
                            throw new Exception("Unable to remove requested row from the SouthernTreasures Products table.");
                        }

                        else
                        {
                            return RetVal.ToString();
                        }
                    }
                }

                catch (Exception ex)
                {
                    //REPLACE WITH MIDDLEWARE LOG WRITE.
                    throw new Exception("Unable to access the SouthernTreasures database: " + ex);
                }
            }
        }
    }
}
