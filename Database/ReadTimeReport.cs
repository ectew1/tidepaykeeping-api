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
            CreateTimeReport.DropTimeReportTable();
            CreateTimeReport.CreateTimeReportTable();

            List<TimeReport> timereports = new List<TimeReport>();

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);

            try
            {
                con.Open();

                string stm = @"SELECT * from timekeepingreport ORDER BY empID ASC";
                using var cmd = new MySqlCommand(stm, con);
                using MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    timereports.Add(new TimeReport()
                    {
                        empID = rdr.GetString(0),
                        dayofwork = rdr.GetDateTime(1),
                        clockinHour = rdr.GetString(2),
                        clockoutHour = rdr.GetString(3),
                        total = rdr.GetDouble(4)
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
            //CreateTimeReport remake = new CreateTimeReport();
            CreateTimeReport.DropTimeReportTable();
            CreateTimeReport.CreateTimeReportTable();

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
                    clockinHour = rdr.GetString(2),
                    clockoutHour = rdr.GetString(3),
                    total = rdr.GetDouble(4)
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

        public List<TimeReport> Get(string empID, DateTime startDate, DateTime endDate)
        {
            //CreateTimeReport remake = new CreateTimeReport();
            CreateTimeReport.DropTimeReportTable();
            CreateTimeReport.CreateTimeReportTable();

            List<TimeReport> tempReport = new List<TimeReport>();

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);

            try
            {
                con.Open();

                string stm = @"SELECT * from timekeepingreport WHERE empID = @empID AND dayofwork BETWEEN @startDate AND @endDate";

                using var cmd = new MySqlCommand(stm, con);
                cmd.Parameters.AddWithValue("@empID", empID);
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.Parameters.AddWithValue("@endDate", endDate);
                cmd.Prepare();
                using MySqlDataReader rdr = cmd.ExecuteReader();

                //rdr.Read();
                while (rdr.Read())
                {
                    tempReport.Add(new TimeReport()
                    {
                        empID = rdr.GetString(0),
                        dayofwork = rdr.GetDateTime(1),
                        clockinHour = rdr.GetString(2),
                        clockoutHour = rdr.GetString(3),
                        total = rdr.GetDouble(4)
                    });
                }
                return tempReport;
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