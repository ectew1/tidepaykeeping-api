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
            CreateTimeReport.AlterTimeReportTable();

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
                        total = rdr.GetDouble(4),
                        timelogID = rdr.GetInt32(5)
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
            CreateTimeReport.AlterTimeReportTable();

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
                    total = rdr.GetDouble(4),
                    timelogID = rdr.GetInt32(5)
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
            CreateTimeReport.DropTimeReportTable();
            CreateTimeReport.CreateTimeReportTable();
            CreateTimeReport.AlterTimeReportTable();

            List<TimeReport> tempReport = new List<TimeReport>();

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);

            try
            {
                con.Open();

                string stm = @"SELECT empID, dayname(dayofwork), dayofwork, clockinHour, clockoutHour, total, timelogID 
                from timekeepingreport 
                WHERE empID = @empID AND dayofwork BETWEEN @startDate AND @endDate";
                using var cmd = new MySqlCommand(stm, con);
                cmd.Parameters.AddWithValue("@empID", empID);
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.Parameters.AddWithValue("@endDate", endDate);
                cmd.Prepare();
                using MySqlDataReader rdr = cmd.ExecuteReader();

                //rdr.Read();
                while (rdr.Read())
                {
                    //DateTime temp = rdr.GetDateTime(2);
                    tempReport.Add(new TimeReport()
                    {
                        empID = rdr.GetString(0),
                        weekday = rdr.GetString(1),
                        dayofwork = rdr.GetDateTime(2),
                        clockinHour = rdr.GetString(3),
                        clockoutHour = rdr.GetString(4),
                        total = rdr.GetDouble(5),
                        timelogID = rdr.GetInt32(6)
                        
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
        public List<TimeReport> Get(DateTime startDate, DateTime endDate)
        {
            //CreateTimeReport remake = new CreateTimeReport();
            CreateTimeReport.DropTimeReportTable();
            CreateTimeReport.CreateTimeReportTable();
            CreateTimeReport.AlterTimeReportTable();

            List<TimeReport> tempReport = new List<TimeReport>();

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);

            try
            {
                con.Open();

                string stm = @"SELECT * from timekeepingreport WHERE dayofwork BETWEEN @startDate AND @endDate";

                using var cmd = new MySqlCommand(stm, con);
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
                        total = rdr.GetDouble(4),
                        timelogID = rdr.GetInt32(5)
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

        public List<TimeReport> Get(string empID, DateTime startDate, DateTime endDate, int i)
        {
            // CreateTimeReport.DropTimeReportTable();
            // CreateTimeReport.CreateTimeReportTable();
            
            List<TimeReport> sortedReport = new List<TimeReport>();

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);

            if(i == 1)
            {
                try
                {
                    con.Open();

                    string stm = @"SELECT empID, dayname(dayofwork), dayofwork, clockinHour, clockoutHour, total, timelogID
                    from timekeepingreport 
                    WHERE empID = @empID AND dayofwork BETWEEN @startDate AND @endDate
                    order by weekday(dayofwork)";
                    using var cmd = new MySqlCommand(stm, con);
                    cmd.Parameters.AddWithValue("@empID", empID);
                    cmd.Parameters.AddWithValue("@startDate", startDate);
                    cmd.Parameters.AddWithValue("@endDate", endDate);
                    cmd.Prepare();
                    using MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        sortedReport.Add(new TimeReport()
                        {
                            empID = rdr.GetString(0),
                            weekday = rdr.GetString(1),
                            dayofwork = rdr.GetDateTime(2),
                            clockinHour = rdr.GetString(3),
                            clockoutHour = rdr.GetString(4),
                            total = rdr.GetDouble(5),
                            timelogID = rdr.GetInt32(6)
                            
                        });
                        
                    }
                    return sortedReport;
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
            else if(i == 2)
            {
                try
                {
                    con.Open();

                    string stm = @"SELECT empID, dayname(dayofwork), dayofwork, clockinHour, clockoutHour, total 
                    from timekeepingreport 
                    WHERE empID = @empID AND dayofwork BETWEEN @startDate AND @endDate
                    order by total desc";
                    using var cmd = new MySqlCommand(stm, con);
                    cmd.Parameters.AddWithValue("@empID", empID);
                    cmd.Parameters.AddWithValue("@startDate", startDate);
                    cmd.Parameters.AddWithValue("@endDate", endDate);
                    cmd.Prepare();
                    using MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        sortedReport.Add(new TimeReport()
                        {
                            empID = rdr.GetString(0),
                            weekday = rdr.GetString(1),
                            dayofwork = rdr.GetDateTime(2),
                            clockinHour = rdr.GetString(3),
                            clockoutHour = rdr.GetString(4),
                            total = rdr.GetDouble(5)
                            
                        });
                        
                    }
                    return sortedReport;
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
            else
            {
                return null;
            }
        }
       
    }
}