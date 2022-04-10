using System;
using MySql.Data.MySqlClient;
using tidepaykeeping_api.Interfaces;
using tidepaykeeping_api.Models;

namespace tidepaykeeping_api.Database
{
    public class DeleteEmployee : IDeleteEmployee
    {
        public void Delete(int id)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            //prepared statements to prevent sql injections
            string stm = @"DELETE from employee WHERE empID = @id";
            using var cmd = new MySqlCommand(stm, con);

            //now identifying what those @ really mean
            cmd.Parameters.AddWithValue("@id", id);
            
            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}