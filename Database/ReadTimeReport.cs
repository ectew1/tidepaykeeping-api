using System.Security.AccessControl;
using System.Collections.Generic;
using System;
using tidepaykeeping_api.Interfaces;
using tidepaykeeping_api.Models;
using MySql.Data.MySqlClient;

namespace tidepaykeeping_api.Database
{
    public class ReadTimeReport : IReadTimeReports
    {
        public List<TimeReport> Get()
        {
            List<TimeReport> timelogs = new List<TimeReport>();

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);

            try
            {
                con.Open();

                string stm = @"SELECT 
	            * from timekeepingreport;";
                using var cmd = new MySqlCommand(stm, con);
                using MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    timelogs.Add(new TimeReport()
                    {
                        empID = rdr.GetString(0),
                        dayofwork = rdr.GetDateTime(1),
                        clockIn = rdr.GetDateTime(2),
                        clockOut = rdr.GetDateTime(3),
                        totalHours = rdr.GetInt64(4)
                    });
                }
                return timelogs;
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
            TimeReport tempLog = new TimeReport();

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);

            try
            {
                con.Open();

                string stm = @"SELECT 
	            * from timekeepingreport WHERE empID = @id;";

                using var cmd = new MySqlCommand(stm, con);
                cmd.Parameters.AddWithValue("@id", empID);
                cmd.Prepare();
                using MySqlDataReader rdr = cmd.ExecuteReader();

                 rdr.Read();
                return new TimeReport()
                {
                    empID = rdr.GetString(0),
                    dayofwork = rdr.GetDateTime(1),
                    clockIn = rdr.GetDateTime(2),
                    clockOut = rdr.GetDateTime(3),
                    totalHours = rdr.GetInt64(4),
                };
                // rdr.Read();
                
                // TimeReport tempLog = new TimeReport(){ dayofwork = rdr.GetDateTime(1), clockIn = rdr.GetDateTime(2), clockOut = rdr.GetDateTime(3),  totalHours = rdr.GetInt64(4)};
                

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

        // public Timelog GetOpenTimelog(string empID, DateTime clockOut)
        // {
        //     Timelog myTimelog = new Timelog();

        //     ConnectionString myConnection = new ConnectionString();
        //     string cs = myConnection.cs;

        //     using var con = new MySqlConnection(cs);

        //     try
        //     {
        //         con.Open();

        //         string stm = @"SELECT * from timekeeping WHERE empID = @empID and clockOut = @clockOut";

        //         using var cmd = new MySqlCommand(stm, con);

        //         cmd.Parameters.AddWithValue("@empID", empID);
        //         cmd.Parameters.AddWithValue("@clockOut", clockOut);
        //         cmd.Prepare();
        //         using MySqlDataReader rdr = cmd.ExecuteReader();

        //         rdr.Read();
        //         return new Timelog()
        //         {
        //             timelogID = rdr.GetInt32(0),
        //             clockIn = rdr.GetDateTime(1),
        //             clockOut = rdr.GetDateTime(2),
        //             empID = rdr.GetString(3),
        //         };
        //     }
        //     catch (Exception)
        //     {
        //         return null;
        //     }
        //     finally
        //     {
        //         con.Close();
        //     }

        // }
    }
}