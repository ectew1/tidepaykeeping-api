using System;
using MySql.Data.MySqlClient;
using tidepaykeeping_api.Interfaces;
using tidepaykeeping_api.Models;

namespace tidepaykeeping_api.Database
{
    public class UpdateTimelog : IUpdateTimelog
    {
        public void Update(Timelog timelog)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"UPDATE timekeeping SET clockOut = @clockOut WHERE empID = @empID AND clockOut = '2012-12-21 03:00:00'";
            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@empID", timelog.empID);
            cmd.Parameters.AddWithValue("@clockOut", DateTime.Now);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}