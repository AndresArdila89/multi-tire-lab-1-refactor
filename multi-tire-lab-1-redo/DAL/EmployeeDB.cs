using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using multi_tire_lab_1_redo.BLL;

namespace multi_tire_lab_1_redo.DAL
{
    public static class EmployeeDB
    {
        public static List<Employee> ListAllRecords()
        {
            //declare the object connection and command
            SqlConnection conn = new SqlConnection();
            SqlCommand cmdSelect = new SqlCommand();
            List<Employee> empList = new List<Employee>();

            //pass the connection to the new object conn
            conn = UtilityDB.ConnectDB();

            //assign the connection to the command object
            cmdSelect.Connection = conn;

            //created the query
            cmdSelect.CommandText = "SELECT * FROM Employees";

            //store the result from the query in an SqlDataReader variable
            SqlDataReader dataReader = cmdSelect.ExecuteReader();


            //read all the information store in the dataReader variable and save it into an object type Employee
            while (dataReader.Read())
            {
                Employee emp = new Employee();

                emp.EmployeeId = Convert.ToInt32(dataReader["EmployeeId"]);
                emp.FirstName = dataReader["FirstName"].ToString();
                emp.LastName = dataReader["LastName"].ToString();
                emp.JobTitle = dataReader["JobTitle"].ToString();

                empList.Add(emp);
            }

            return empList;
            
        }

        public static void NewRecord(Employee emp)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdInsert = new SqlCommand();

            cmdInsert.CommandText = "INSERT INTO Employees(FirstName,LastName,JobTitle) Values(@FirstName,@LastName,@JobTitle)";
            cmdInsert.Parameters.AddWithValue("@FirstName", emp.FirstName);
            cmdInsert.Parameters.AddWithValue("@LastName", emp.LastName);
            cmdInsert.Parameters.AddWithValue("@JobTitle", emp.JobTitle);
            cmdInsert.Connection = conn;
            cmdInsert.ExecuteNonQuery();
            conn.Close();
        }

        public static Employee SearchRecords(int empId)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdSelect = new SqlCommand();

            cmdSelect.Connection = conn;
            cmdSelect.CommandText = "SELECT * FROM Employees WHERE EmployeeId = @EmployeeId";
            cmdSelect.Parameters.AddWithValue("@EmployeeId", empId);

            SqlDataReader dataReader = cmdSelect.ExecuteReader();


            dataReader.Read();
            Employee empTemp = new Employee();

                empTemp.EmployeeId = Convert.ToInt32(dataReader["EmployeeId"]);
                empTemp.FirstName = dataReader["FirstName"].ToString();
                empTemp.LastName = dataReader["LastName"].ToString();
                empTemp.JobTitle = dataReader["JobTitle"].ToString();


            conn.Close();

            return empTemp;

        }

        public static List<Employee> SearchRecords(string empName)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdSelect = new SqlCommand();

            cmdSelect.Connection = conn;
            cmdSelect.CommandText = "SELECT * FROM Employees WHERE FirstName = @FirstName OR LastName = @LastName";
            cmdSelect.Parameters.AddWithValue("@FirstName", empName);
            cmdSelect.Parameters.AddWithValue("@LastName", empName);

            SqlDataReader dataReader = cmdSelect.ExecuteReader();

            List<Employee> empList = new List<Employee>();

            while (dataReader.Read())
            {
                Employee empTemp = new Employee();

                empTemp.EmployeeId = Convert.ToInt32(dataReader["EmployeeId"]);
                empTemp.FirstName = dataReader["FirstName"].ToString();
                empTemp.LastName = dataReader["LastName"].ToString();
                empTemp.JobTitle = dataReader["JobTitle"].ToString();

                empList.Add(empTemp);

            }

            conn.Close();
            
            return empList;

        }

        public static void UpdateRecord(Employee emp)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdUpdate = new SqlCommand();

            cmdUpdate.Connection = conn;
            cmdUpdate.CommandText = "UPDATE Employees SET FirstName = @FirstName, LastName = @LastName, JobTitle = @JobTitle WHERE EmployeeId = @EmployeeId";

            cmdUpdate.Parameters.AddWithValue("@FirstName", emp.FirstName);
            cmdUpdate.Parameters.AddWithValue("@LastName", emp.LastName);
            cmdUpdate.Parameters.AddWithValue("@JobTitle", emp.JobTitle);
            cmdUpdate.Parameters.AddWithValue("@EmployeeId", emp.EmployeeId);

            cmdUpdate.ExecuteNonQuery();

            conn.Close();
        }

        public static void DeleteRecord(int empId)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdDelete = new SqlCommand();

            cmdDelete.Connection = conn;
            cmdDelete.CommandText = "DELETE FROM Employees WHERE EmployeeId = @EmployeeId";
            cmdDelete.Parameters.AddWithValue("@EmployeeId", empId);

            cmdDelete.ExecuteNonQuery();

        }

        


    }
}
