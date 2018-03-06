using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.ServiceModel;
using Acme.Service.DataContracts;

namespace Acme.Service
{
    public class AcmeService : IAcmeService
    {
        public SqlConnection con;
        public SqlCommand cmd;
        public SqlDataAdapter da;
        public DataSet ds;
        public DataTable dt;

        string connectionString = ConfigurationManager.ConnectionStrings["AcmeConnectionString"].ConnectionString;

        private void Connection_Data()
        {
            con = new SqlConnection(connectionString);
            cmd = new SqlCommand
            {
                Connection = con
            };
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            dt = new DataTable();
        }

        public string AddEmployee(Employee emp)
        {
            string result = "";
            Connection_Data();

            con.Open();

            try
            {
                //Insert data into database
                cmd.CommandText = "InsertEmployee";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("LastName", emp.LastName);
                cmd.Parameters.AddWithValue("FirstName", emp.FirstName);
                cmd.Parameters.AddWithValue("BirthDate", emp.BirthDate);
                cmd.Parameters.AddWithValue("EmployeeNumber", emp.EmployeeNumber);
                cmd.Parameters.AddWithValue("EmployedDate", emp.EmployedDate);
                cmd.Parameters.AddWithValue("TermindatedDate", emp.TerminatedDate);
                cmd.ExecuteNonQuery();
                con.Close();

                result = $"Employee, { emp.EmployeeNumber }, inserted Successfully!";

            }
            catch (Exception ex)
            {
                string whichOne = ex.InnerException == null ? ex.Message : ex.InnerException.ToString();
                result = $"Error inserting record for employee { emp.EmployeeNumber}. Error details: { whichOne }";
            }
            return result;
        }

        public string UpdateEmployee(Employee emp)
        {
            string result = "";
            Connection_Data();

            con.Open();

            try
            {
                //Update record in database
                cmd.CommandText = "UpdateEmployee";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PersonId", emp.PersonId);
                cmd.Parameters.AddWithValue("@LastName", emp.LastName);
                cmd.Parameters.AddWithValue("@FirstName", emp.FirstName);
                cmd.Parameters.AddWithValue("@BirthDate", emp.BirthDate);
                cmd.Parameters.AddWithValue("@EmployeeNumber", emp.EmployeeNumber);
                cmd.Parameters.AddWithValue("@EmployedDate", emp.EmployedDate);
                cmd.Parameters.AddWithValue("@TermindatedDate", emp.TerminatedDate);
                cmd.ExecuteNonQuery();
                con.Close();

                result = $"Employee, { emp.EmployeeNumber } , updated successfully!";

            }
            catch (Exception ex)
            {
                string whichOne = ex.InnerException == null ? ex.Message : ex.InnerException.ToString();
                result = $"Error updating record for employee { emp.EmployeeNumber }. Error Message { whichOne }";
            }
            return result;
        }

        public string DeleteEmployee(Employee emp)
        {
            string result = "";
            Connection_Data();

            con.Open();

            try
            {
                //Delete record from database
                cmd.CommandText = "DeleteEmployee";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("PersonId", emp.PersonId);
                cmd.ExecuteNonQuery();
                con.Close();

                result = $"Employee, { emp.EmployeeNumber }, deleted Successfully!";

            }
            catch (Exception ex)
            {
                string whichOne = ex.InnerException == null ? ex.Message : ex.InnerException.ToString();
                result = $"Error deleting record for employee { emp.EmployeeNumber }. Error details: { whichOne }";
            }
            return result;
        }

        public DataSet GetEmployees()
        {
            DataSet ds = new DataSet();
            Connection_Data();

            con.Open();

            try
            {
                cmd.CommandText = "SelectEmployees";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                SqlDataAdapter sda = new SqlDataAdapter(cmd.CommandText, con);
                sda.Fill(ds);

                con.Close();

            }
            catch (FaultException fex)
            {
                throw new FaultException<string>("Error: " + fex);
            }

            return ds;
        }

        public DataSet SearchEmployee(Employee emp)
        {
            Connection_Data();

            con.Open();

            cmd = new SqlCommand("SelectEmployee", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@EmployeeId", emp.EmployeeId);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteNonQuery();
            con.Close();
            return ds;
        }
    }
}
