using System;
using System.Data;
using System.Data.SqlClient;
using MiddlewareDAL.LogTrace.Models;
using MiddlewareDAL.Connection;

namespace MiddlewareDAL.LogTrace
{
    public class LogTraceDAL
    {
        public string InsertSQL = "INSERT INTO LogTrace ([AppName_Txt], [Message_Txt], [UserName_Txt], [DateTime]) OUTPUT Inserted.ID values(@AppName,@Message,@UserName,@DateTM)";
        public DBConnectionStr SQLDB = new DBConnectionStr();

        public string Validate(LogTraceDALModel Trace)
        {
            //Ensure Trace isn't null
            if (Trace == null)
            {
                return "Log Insert is empty.";
            }

            //Check for empty Application Name
            if (Trace.AppName_Txt == "")
            {
                return "The Application Name in the Log Insert is empty.";
            }

            //Check for empty Log Message
            if (Trace.Message_Txt == "")
            {
                return "The Log Message in the Log Insert is empty.";
            }

            //Check for empty User Name
            if (Trace.UserName_Txt == "")
            {
                return "The User Name in the Log Insert is empty.";
            }

            return "";
        }

        public string Create(LogTraceDALModel Trace)
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
                        Cmd.Parameters.Add("@AppName", SqlDbType.NVarChar).Value = Trace.AppName_Txt;
                        Cmd.Parameters.Add("@Message", SqlDbType.NVarChar).Value = Trace.Message_Txt;
                        Cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = Trace.UserName_Txt;
                        Cmd.Parameters.Add("@DateTM", SqlDbType.DateTime).Value = DateTime.Now;

                        //Execute and Validate
                        string RetVal = Cmd.ExecuteScalar().ToString();
                        if (RetVal == "0")
                        {
                            return "Unable to write to the Middleware LogTrace table.";
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
    }
}