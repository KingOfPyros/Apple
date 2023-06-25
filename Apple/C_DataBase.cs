using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Apple
{
    class C_DataBase
    {
        SqlConnection SqlConnection = new SqlConnection(@"Data Source=SQL6030.site4now.net;Initial Catalog=db_a9b162_illiakursnew2;User Id=db_a9b162_illiakursnew2_admin;Password=qwerty123");

        public void openConnection()
        {
            if (SqlConnection.State == System.Data.ConnectionState.Closed)
            {
                SqlConnection.Open();
            }
        }

        public void closeConnection()
        {
            if (SqlConnection.State == System.Data.ConnectionState.Open)
            {
                SqlConnection.Close();
            }
        }

        public SqlConnection getConnection()
        {
            return SqlConnection;
        }
    }
}
