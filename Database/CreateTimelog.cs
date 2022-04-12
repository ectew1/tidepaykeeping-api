using MySql.Data.MySqlClient;
using tidepaykeeping_api.Interfaces;
using tidepaykeeping_api.Models;

namespace tidepaykeeping_api.Database
{
    public class CreateTimelog : ICreateTimelog
    {
        public void Create(Timelog timelog)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO timekeeping(timelogID, clockInDate, clockOutDate, clockInTime, clockOutTime) VALUES(@timelogID, @clockInDate, @clockOutDate, @clockInTime, @clockOutTime)";
            using var cmd = new MySqlCommand(stm, con);

            //now identifying what those @ really mean
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