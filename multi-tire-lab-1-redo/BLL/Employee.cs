using multi_tire_lab_1_redo.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace multi_tire_lab_1_redo.BLL
{
    public class Employee
    {
        private int employeeId;
        private string firstName;
        private string lastName;
        private string jobTitle;

        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string JobTitle { get => jobTitle; set => jobTitle = value; }



        public  List<Employee> LoadAllEmployees()
        {
            return EmployeeDB.ListAllRecords();
        }

        public void NewEmployee(Employee emp)
        {
            EmployeeDB.NewRecord(emp);
        }


        public Employee SearchEmployee(int empId)
        {
            return EmployeeDB.SearchRecords(empId);
        }

        
        public List<Employee> SearchEmployee(string empName)
        {
            return EmployeeDB.SearchRecords(empName);
        }

        public void UpdateEmployee(Employee emp)
        {
            EmployeeDB.UpdateRecord(emp);
        }


        public void DeleteEmployee(int empId)
        {
            EmployeeDB.DeleteRecord(empId);
        }

    }
}
