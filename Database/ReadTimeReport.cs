using System.Security.AccessControl;
using System.Collections.Generic;
using System;
using tidepaykeeping_api.Interfaces;
using tidepaykeeping_api.Models;
using MySql.Data.MySqlClient;

namespace tidepaykeeping_api.Database
{
    public class ReadTimeReport : IReadAllTimeReports
    {
        public List<TimeReport> Get()
        {
            List<TimeReport> timereports = new List<TimeReport>();

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);

            try
            {
                con.Open();

                string stm = @"SELECT * from timekeepingreport ORDER BY empID DESC";
                using var cmd = new MySqlCommand(stm, con);
                using MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    timereports.Add(new TimeReport()
                    {
                        empID = rdr.GetString(0),
                        dayofwork = rdr.GetDateTime(1),
                        clockinHour = rdr.GetDateTime(2),
                        clockoutHour = rdr.GetDateTime(3),
                        total = rdr.GetInt64(4)
                    });
                }
                return timereports;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public TimeReport Get(string empID)
        {
            TimeReport tempReport = new TimeReport();

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);

            try
            {
                con.Open();

                string stm = @"SELECT * from timekeepingreport WHERE empID = @empID;";

                using var cmd = new MySqlCommand(stm, con);
                cmd.Parameters.AddWithValue("@empID", empID);
                cmd.Prepare();
                using MySqlDataReader rdr = cmd.ExecuteReader();

                rdr.Read();
                return new TimeReport()
                {
                    empID = rdr.GetString(0),
                    dayofwork = rdr.GetDateTime(1),
                    clockinHour = rdr.GetDateTime(2),
                    clockoutHour = rdr.GetDateTime(3),
                    total = rdr.GetInt64(4)
                };
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
       
    }
}