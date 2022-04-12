using System;
using MySql.Data.MySqlClient;
using tidepaykeeping_api.Interfaces;
using tidepaykeeping_api.Models;

namespace tidepaykeeping_api.Database
{
    public class DeleteTimelog : IDeleteTimelog
    {
        public void Delete(int id)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"DELETE from timekeeping WHERE timelogID = @id";
            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@id", id);
            
            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}