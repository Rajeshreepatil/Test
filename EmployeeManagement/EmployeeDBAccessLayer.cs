using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    public class EmployeeDBAccessLayer
    {
        SqlConnection con = new SqlConnection("Data Source=HIJ-LP091\\MSSQLSERVER2017;Initial Catalog=EmployeeData;Integrated Security=True");

        public string AddEmployeeRecord(EmployeeEntities employeeEntities)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_Employee_Add", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Emp_Name", employeeEntities.Emp_Name);
                cmd.Parameters.AddWithValue("@Class", employeeEntities.Age);
                cmd.Parameters.AddWithValue("@Age", employeeEntities.Age);
             
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Data save Successfully");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return (ex.Message.ToString());
            }
        }
    }
}
