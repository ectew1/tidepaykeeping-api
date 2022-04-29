using System.Security.AccessControl;
using System.Collections.Generic;
using System;
using tidepaykeeping_api.Interfaces;
using tidepaykeeping_api.Models;
using MySql.Data.MySqlClient;

namespace tidepaykeeping_api.Database
{
    public class ReadTimelog : IReadAllTimelogs, IReadOneTimelog
    {
        public List<Timelog> Get()
        {
            List<Timelog> timelogs = new List<Timelog>();

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);

            try
            {
                con.Open();

                string stm = @"SELECT * from
                timekeeping;";
                using var cmd = new MySqlCommand(stm, con);
                using MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    timelogs.Add(new Timelog()
                    {
                        
                    timelogID = rdr.GetInt32(0),
                    clockIn = rdr.GetDateTime(1),
                    clockOut = rdr.GetDateTime(2),
                    empID = rdr.GetString(3),
                        
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

        public Timelog Get(int id)
        {
            //Timelog tempLog = new Timelog();

            // ConnectionString myConnection = new ConnectionString();
            // string cs = myConnection.cs;

            // using var con = new MySqlConnection(cs);

            // try
            // {
            //     con.Open();

            //     string stm = @"SELECT 
	        //     empID,
            //     DATE(clockIn) AS dayofwork,
            //     DATE_FORMAT(TIME(clockIn), '%r') AS clockinHour,
            //     DATE_FORMAT(TIME(clockOut), '%r') AS clockoutHour,
            //     CONVERT( TIMESTAMPDIFF(MINUTE, clockIn, clockOut) / 60 , DECIMAL (4 , 2 )) AS total
            //     FROM
            //     timekeeping WHERE empID = @id;";

            //     using var cmd = new MySqlCommand(stm, con);
            //     cmd.Parameters.AddWithValue("@id", empID);
            //     cmd.Prepare();
            //     using MySqlDataReader rdr = cmd.ExecuteReader();

            
            //     rdr.Read();
                
            //     Timelog tempLog = new Timelog(){empID = rdr.GetString(0), dayofwork = rdr.GetDateTime(1), clockIn = rdr.GetDateTime(2), clockOut = rdr.GetDateTime(3),  totalHours = rdr.GetInt64(4)};
                

            // Console.WriteLine(tempLog);
            // return tempLog;
            // }
            // catch (Exception)
            // {
            //     return null;
            // }
            // finally
            // {
            //     con.Close();
            // }
            return null;
        }

        public Timelog GetOpenTimelog(string empID, DateTime clockOut)
        {
            Timelog myTimelog = new Timelog();

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);

            try
            {
                con.Open();

                string stm = @"SELECT * from timekeeping WHERE empID = @empID and clockOut = @clockOut";

                using var cmd = new MySqlCommand(stm, con);

                cmd.Parameters.AddWithValue("@empID", empID);
                cmd.Parameters.AddWithValue("@clockOut", clockOut);
                cmd.Prepare();
                using MySqlDataReader rdr = cmd.ExecuteReader();

                rdr.Read();
                return new Timelog()
                {
                    timelogID = rdr.GetInt32(0),
                    clockIn = rdr.GetDateTime(1),
                    clockOut = rdr.GetDateTime(2),
                    empID = rdr.GetString(3),
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