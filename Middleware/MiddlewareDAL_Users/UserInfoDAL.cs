using System;
using System.Data;
using System.Data.SqlClient;
using MiddlewareDAL.Users.Models;
using MiddlewareDAL.Connection;
using Newtonsoft.Json;

namespace MiddlewareDAL.Users
{
    public class UserInfoDAL
    {
        public string InsertSQL = "INSERT INTO Users ([Name_Txt], [Password_Txt], [Email_Txt], [Money_Dec]) OUTPUT Inserted.ID values(@Name, @Password, @Email, @Money)";
        public string RetrieveSQL = "SELECT [ID], [Name_Txt], [Password_Txt], [Email_Txt], [Money_Dec] FROM Users WHERE [Name_Txt] = @Name AND [Password_Txt] = @Password";
        public string UpdateSQL = "UPDATE Users SET [Name_Txt] = @Name, [Password_Txt] = @Password, [Email_Txt] = @Email, [Money_Dec] = @Money WHERE [ID] = @ID";
        public string DeleteSQL = "DELETE FROM Users WHERE [ID] = @ID";
        public DBConnectionStr SQLDB = new DBConnectionStr();

        public string Validate(UsersDALModel UserInfo)
        {
            //Ensure UserInfo isn't null
            if (UserInfo == null)
            {
                return "User Insert is empty.";
            }

            //Check for empty User Name
            if (UserInfo.Name_Txt == "")
            {
                return "The User Name in the User Insert is empty.";
            }

            //Check for empty Password
            if (UserInfo.Password_Txt == "")
            {
                return "The Password in the User Insert is empty.";
            }

            //Check for empty Email
            if (UserInfo.Email_Txt == "")
            {
                return "The Email in the User Insert is empty.";
            }

            //Check for empty Balance
            if (UserInfo.Money_Dec == 0)
            {
                return "The Money Balance in the User Insert is empty.";
            }

            //Check for negative Balance
            if (UserInfo.Money_Dec < 0)
            {
                return "The Money Balance in the User Insert is Negative.";
            }

            return "";
        }

        public string ValidateKey(UsersDALModel UserInfo)
        {
            //Ensure UserInfo isn't null
            if(UserInfo == null)
            {
                return "User Update is empty.";
            }

            //Ensure a key is provided
            if(UserInfo.ID < 1)
            {
                return "The Primary Key was not provided for the User Update.";
            }

            return "";
        }

        public string Create(UsersDALModel UserInfo)
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
                        Cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = UserInfo.Name_Txt;
                        Cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = UserInfo.Password_Txt;
                        Cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = UserInfo.Email_Txt;
                        Cmd.Parameters.Add("@Money", SqlDbType.Decimal).Value = UserInfo.Money_Dec;

                        //Execute and Validate
                        string RetVal = Cmd.ExecuteScalar().ToString();
                        if (RetVal == "0")
                        {
                            return "Unable to write to the Middleware Users table.";
                        }

                        else
                        {
                            return RetVal;
                        }
                    }
                }

                catch (Exception ex)
                {
                    return "Unable to access the Middleware database: " + ex;
                }
            }
        }

        public string Retrieve(UsersDALModel UserInfo)
        {
            using (SQLDB.SQLConnection)
            {
                try
                {
                    SQLDB.SQLConnection.Open();

                    //Retrieve
                    using (SqlCommand Cmd = new SqlCommand(RetrieveSQL, SQLDB.SQLConnection))
                    {
                        //Set up Parameters
                        Cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = UserInfo.Name_Txt;
                        Cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = UserInfo.Password_Txt;

                        //Retrieve data
                        using (SqlDataReader InpReader = Cmd.ExecuteReader())
                        {
                            while (InpReader.Read())
                            {

                                UserInfo.ID = Convert.ToInt32(InpReader["ID"]);
                                UserInfo.Name_Txt = InpReader["Name_Txt"].ToString();
                                UserInfo.Password_Txt = InpReader["Password_Txt"].ToString();
                                UserInfo.Email_Txt = InpReader["Email_Txt"].ToString();
                                UserInfo.Money_Dec = Convert.ToDecimal(InpReader["Money_Dec"]);
                            }
                        }

                        //Validate if valid
                        if (UserInfo.ID <= 0)
                        {
                            return "Nothing found with this Login Info in the Middleware Users table.";
                        }

                        else
                        {
                            return JsonConvert.SerializeObject(UserInfo);
                        }
                    }
                }

                catch (Exception ex)
                {
                    return "Unable to access the Middleware database: " + ex;
                }
            }
        }

        public string Update(UsersDALModel UserInfo)
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
                        Cmd.Parameters.Add("@ID", SqlDbType.Int).Value = UserInfo.ID;
                        Cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = UserInfo.Name_Txt;
                        Cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = UserInfo.Password_Txt;
                        Cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = UserInfo.Email_Txt;
                        Cmd.Parameters.Add("@Money", SqlDbType.Decimal).Value = UserInfo.Money_Dec;

                        //Execute and Validate
                        int RetVal = Cmd.ExecuteNonQuery();
                        if (RetVal == 0)
                        {
                            return "Unable to update the Middleware Users table.";
                        }

                        else
                        {
                            return RetVal.ToString();
                        }
                    }
                }

                catch (Exception ex)
                {
                    return "Unable to access the Middleware database: " + ex;
                }
            }
        }

        public string Delete(UsersDALModel UserInfo)
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
                        Cmd.Parameters.Add("@ID", SqlDbType.Int).Value = UserInfo.ID;

                        //Execute and Validate
                        int RetVal = Cmd.ExecuteNonQuery();
                        if (RetVal == 0)
                        {
                            return "Unable to remove requested row from the Middleware Users table.";
                        }

                        else
                        {
                            return RetVal.ToString();
                        }
                    }
                }

                catch (Exception ex)
                {
                    return "Unable to access the Middleware database: " + ex;
                }
            }
        }
    }
}