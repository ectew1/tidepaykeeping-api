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

        public void UpdateMgr(Timelog timelog)
        {
            Console.WriteLine("Inside Update");
            Console.WriteLine(timelog.timelogID);
            Console.WriteLine(timelog.NewclockIn);
            Console.WriteLine(timelog.NewclockOut);
            Console.WriteLine(timelog.empID);
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"UPDATE timekeeping SET clockOut = @clockOut,clockIn = @clockIn WHERE empID = @empID AND timelogID = @timelogID";
            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@empID", timelog.empID);
            cmd.Parameters.AddWithValue("@clockIn", timelog.NewclockIn);
            cmd.Parameters.AddWithValue("@clockOut", timelog.NewclockOut);
            cmd.Parameters.AddWithValue("@timelogID",timelog.timelogID);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}