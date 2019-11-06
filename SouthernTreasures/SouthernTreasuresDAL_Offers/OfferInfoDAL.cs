using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using SouthernTreasuresDAL.Connection;
using SouthernTreasuresDAL.Offers.Model;

namespace SouthernTreasuresDAL.Offers
{
    public class OfferInfoDAL
    {
        public string InsertSQL = "INSERT INTO Offers ([UserID_Nbr], [ProductID_Nbr], [Price_Dec], [Submitted_DtTM]) OUTPUT Inserted.ID values(@UserID, @CategoryID, @Price, @Submitted)";
        public string RetrieveSQL = "SELECT [ID], [UserID_Nbr], [ProductID_Nbr], [Price_Dec], [Submitted_DtTM] FROM Offers";
        public string RetrieveByIDSQL = "SELECT [ID], [UserID_Nbr], [ProductID_Nbr], [Price_Dec], [Submitted_DtTM] FROM Offers WHERE [ID] = @ID;";
        public string UpdateSQL = "UPDATE Offers SET [UserID_Nbr] = @UserID, [ProductID_Nbr] = @ProductID, [Price_Dec] = @Price, [Submitted_DtTM] = @Submitted WHERE [ID] = @ID";
        public string DeleteSQL = "DELETE FROM Offers WHERE [ID] = @ID";
        public DBConnectionStr SQLDB = new DBConnectionStr();

        public string Validate(OffersDALModel OfferInfo)
        {
            //Ensure OfferInfo isn't null
            if (OfferInfo == null)
            {
                return "Offer Object is empty.";
            }

            //Check for blank User ID
            if (OfferInfo.UserID_Nbr == 0)
            {
                return "The Offer User ID is blank in the Offer Insert request.";
            }

            //Check for blank Product ID
            if (OfferInfo.ProductID_Nbr == 0)
            {
                return "The Offer Product ID is blank in the Offer Insert request.";
            }

            //Check for invalid Price
            if (OfferInfo.Price_Dec <= 0)
            {
                return "The Offer Price is invalid in the Offer Insert request.";
            }

            return "";
        }

        public string ValidateKey(OffersDALModel OfferInfo)
        {
            //Ensure OfferInfo isn't null
            if (OfferInfo == null)
            {
                return "Offer Object is empty.";
            }

            //Ensure a key is provided
            if (OfferInfo.ID < 1)
            {
                return "The Primary Key was not provided for the Offer Update.";
            }

            return "";
        }

        public string Create(OffersDALModel OfferInfo)
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
                        Cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = OfferInfo.UserID_Nbr;
                        Cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = OfferInfo.ProductID_Nbr;
                        Cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = OfferInfo.Price_Dec;
                        Cmd.Parameters.Add("@Submitted", SqlDbType.DateTime).Value = DateTime.Now;

                        //Execute and Validate
                        string RetVal = Cmd.ExecuteScalar().ToString();
                        if (RetVal == "0")
                        {
                            //REPLACE WITH MIDDLEWARE LOG WRITE.
                            throw new Exception("Unable to write to the SouthernTreasures Categories table.");
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

        public List<OffersDALModel> Retrieve()
        {
            List<OffersDALModel> OffersInfo = new List<OffersDALModel>();
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
                                OffersInfo.Add(new OffersDALModel(
                                    Convert.ToInt32(InpReader["ID"]),
                                    Convert.ToInt32(InpReader["UserID_Txt"]),
                                    Convert.ToInt32(InpReader["ProductID_Txt"]),
                                    Convert.ToDecimal(InpReader["Price_Dec"]),
                                    Convert.ToDateTime(InpReader["Submitted_DtTM"])
                                    ));
                            }
                        }

                        //Validate if valid
                        if (OffersInfo.Count == 0)
                        {
                            //REPLACE WITH MIDDLEWARE LOG WRITE.
                            throw new Exception("Nothing found in the SouthernTreasures Offers table.");
                        }
                    }
                }

                catch (Exception ex)
                {
                    //REPLACE WITH MIDDLEWARE LOG WRITE.
                    throw new Exception("Unable to access the SouthernTreasures database: " + ex);
                }

                return OffersInfo;
            }
        }

        public OffersDALModel RetrieveByID(int ID)
        {
            OffersDALModel OfferInfo = new OffersDALModel();
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
                                OfferInfo = new OffersDALModel(
                                    Convert.ToInt32(InpReader["ID"]),
                                    Convert.ToInt32(InpReader["UserID_Txt"]),
                                    Convert.ToInt32(InpReader["ProductID_Txt"]),
                                    Convert.ToDecimal(InpReader["Price_Dec"]),
                                    Convert.ToDateTime(InpReader["Submitted_DtTM"])
                                );
                            }
                        }

                        //Validate if valid
                        if (OfferInfo.UserID_Nbr == 0)
                        {
                            //REPLACE WITH MIDDLEWARE LOG WRITE.
                            throw new Exception("Nothing found with this ID in the SouthernTreasures Offers table.");
                        }
                    }
                }

                catch (Exception ex)
                {
                    //REPLACE WITH MIDDLEWARE LOG WRITE.
                    throw new Exception("Unable to access the SouthernTreasures database: " + ex);
                }

                return OfferInfo;
            }
        }

        public string Update(OffersDALModel OfferInfo)
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
                        Cmd.Parameters.Add("@ID", SqlDbType.Int).Value = OfferInfo.ID;
                        Cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = OfferInfo.UserID_Nbr;
                        Cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = OfferInfo.ProductID_Nbr;
                        Cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = OfferInfo.Price_Dec;
                        Cmd.Parameters.Add("@Submitted", SqlDbType.DateTime).Value = DateTime.Now;

                        //Execute and Validate
                        int RetVal = Cmd.ExecuteNonQuery();
                        if (RetVal == 0)
                        {
                            //REPLACE WITH MIDDLEWARE LOG WRITE.
                            throw new Exception("Unable to update the SouthernTreasures Offers table.");
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
                            throw new Exception("Unable to remove requested row from the SouthernTreasures Offer table.");
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
