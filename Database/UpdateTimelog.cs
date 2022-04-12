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

            string stm = @"UPDATE timekeeping SET timelogID = @timelogID, clockInDate = @clockInDate, clockOutDate = @clockOutDate, clockInTime = @clockInTime, clockOutTime = @clockOutTime";
            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@timelogID", timelog.timelogID);
            cmd.Parameters.AddWithValue("@clockInDate", timelog.clockInDate);
            cmd.Parameters.AddWithValue("@clockOutDate", timelog.clockOutDate);
            cmd.Parameters.AddWithValue("@clockInTime", timelog.clockInTime);
            cmd.Parameters.AddWithValue("@clockOutTime", timelog.clockOutTime);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}