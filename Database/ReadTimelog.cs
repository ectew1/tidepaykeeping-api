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

                string stm = @"SELECT * from timekeeping ORDER BY timelogID DESC";

                using var cmd = new MySqlCommand(stm, con);
                using MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    timelogs.Add(new Timelog()
                    {
                        timelogID = rdr.GetString(0),
                        clockInDate = rdr.GetDateTime(1),
                        clockOutDate = rdr.GetDateTime(2),
                        clockInTime = rdr.GetDateTime(3),
                        clockOutTime = rdr.GetDateTime(4)
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
            Timelog myTimelog = new Timelog();

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);

            try
            {
                con.Open();

                string stm = @"SELECT * from timekeeping WHERE timelogID = @id";

                using var cmd = new MySqlCommand(stm, con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Prepare();
                using MySqlDataReader rdr = cmd.ExecuteReader();

                rdr.Read();
                return new Timelog()
                {
                    timelogID = rdr.GetString(0),
                    clockInDate = rdr.GetDateTime(1),
                    clockOutDate = rdr.GetDateTime(2),
                    clockInTime = rdr.GetDateTime(3),
                    clockOutTime = rdr.GetDateTime(4)
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