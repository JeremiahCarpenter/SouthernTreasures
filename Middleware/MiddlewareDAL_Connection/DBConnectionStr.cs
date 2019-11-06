using System.Configuration;
using System.Data.SqlClient;
using System;

namespace MiddlewareDAL.Connection
{
    public class DBConnectionStr
    {
        public SqlConnection SQLConnection = new SqlConnection(new SqlConnectionStringBuilder()
        {
            DataSource = ConfigurationManager.AppSettings["DataSource"],
            InitialCatalog = ConfigurationManager.AppSettings["InitialCatalog"],
            IntegratedSecurity = Convert.ToBoolean(ConfigurationManager.AppSettings["IntegratedSecurity"]),
            UserID = ConfigurationManager.AppSettings["UserID"],
            Password = ConfigurationManager.AppSettings["Password"]
        }.ConnectionString
        );
    }
}