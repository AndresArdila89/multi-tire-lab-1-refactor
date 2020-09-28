using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace multi_tire_lab_1_redo.DAL
{
    public static class UtilityDB
    {

        public static SqlConnection ConnectDB()
        {

            SqlConnection connDB = new SqlConnection();

            connDB.ConnectionString = ConfigurationManager.ConnectionStrings["EmployeeDB_Connection"].ConnectionString;
            connDB.Open();
            
            return connDB;
        }
    }
}
