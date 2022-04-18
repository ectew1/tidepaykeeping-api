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

            string stm = @"INSERT INTO timekeeping(timelogID, clockIn, clockOut, empID) VALUES(@timelogID, @clockIn, @clockOut, @empID)";
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