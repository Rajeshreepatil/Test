using System;
using System.Data;
using System.Data.SqlClient;

namespace EmpManagementDB
{
    public class EmployeeDBAccessLayer
    {
        SqlConnection con = new SqlConnection("Data Source=HIJ-LP091\\MSSQLSERVER2017;Initial Catalog=EmployeeData;Integrated Security=True");

        public string AddEmployeeRecord(EmployeeEntities employeeEntities)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_Add_Data", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Emp_Name", employeeEntities.Emp_Name);
                cmd.Parameters.AddWithValue("@Class", employeeEntities.Class);
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
