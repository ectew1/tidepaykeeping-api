using MySql.Data.MySqlClient;
using tidepaykeeping_api.Interfaces;
using tidepaykeeping_api.Models;

namespace tidepaykeeping_api.Database
{
    public class CreateEmployee : ICreateEmployee
    {
        public void Create(Employee employee)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            //prepared statements to prevent sql injections
            string stm = @"INSERT INTO employee(empID, empFName, empLName, salaryByHr, empRole, empEmail, empPassword, managerID) VALUES(@empID, @empFName, @empLName, @salaryByHr, @empRole, @empEmail, @empPassword, @managerID)";
            using var cmd = new MySqlCommand(stm, con);

            //now identifying what those @ really mean
            cmd.Parameters.AddWithValue("@empID", employee.empID);
            cmd.Parameters.AddWithValue("@empFName", employee.empFName);
            cmd.Parameters.AddWithValue("@empLName", employee.empLName);
            cmd.Parameters.AddWithValue("@salaryByHr", employee.salaryByHr);
            cmd.Parameters.AddWithValue("@empRole", employee.empRole);
            cmd.Parameters.AddWithValue("@empEmail", employee.empEmail);
            cmd.Parameters.AddWithValue("@empPassword", employee.empPassword);
            cmd.Parameters.AddWithValue("@managerID", employee.managerID);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}