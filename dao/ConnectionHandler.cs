using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace dao
{
    public class ConnectionHandler
    {
        public static SqlConnection getConnection()
        { 
        string sqlcon = ConfigurationManager.ConnectionStrings["connectionString"].ToString();
            SqlConnection conn = new SqlConnection(sqlcon);
            return conn;
    }
    }
}
