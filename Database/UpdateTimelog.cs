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

            string stm = @"UPDATE timekeeping SET timelogID = @timelogID, clockIn = @clockIn, clockOut = @clockOut, empID = @empID";
            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@timelogID", timelog.timelogID);
            cmd.Parameters.AddWithValue("@clockIn", timelog.clockIn);
            cmd.Parameters.AddWithValue("@clockOut", timelog.clockOut);
            cmd.Parameters.AddWithValue("@empID", timelog.empID);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}