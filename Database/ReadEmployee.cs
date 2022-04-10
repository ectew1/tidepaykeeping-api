using System.Security.AccessControl;
using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;
using tidepaykeeping_api.Interfaces;
using tidepaykeeping_api.Models;

namespace tidepaykeeping_api.Database
{
    public class ReadEmployee : IReadAllEmployees, IReadOneEmployee
    {
        public List<Song> Get()
        {
            List<Song> songs = new List<Song>();

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);

            try
            {
                con.Open();

                //prepared statements to prevent sql injections
                string stm = @"SELECT * from songs ORDER BY Timestamp DESC";

                //while loop from sql lite video
                using var cmd = new MySqlCommand(stm, con);
                using MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    songs.Add(new Song()
                    {
                        SongID = rdr.GetInt32(0),
                        SongTitle = rdr.IsDBNull(1) ? null : rdr.GetString(1),
                        SongTimestamp = rdr.IsDBNull(2) ? DateTime.MinValue : rdr.GetDateTime(2),
                        Deleted = rdr.IsDBNull(3) ? null : rdr.GetString(3),
                        Favorited = rdr.IsDBNull(4) ? null : rdr.GetString(4)
                    });
                    //System.Console.WriteLine($"{rdr.GetInt32(0)} {rdr.GetString(1)} {rdr.GetDateTime(2)} {rdr.GetString(3)}");
                }
                return songs;
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

        public Song Get(int id)
        {
            Song mySong = new Song();

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);

            try
            {
                con.Open();

                //prepared statements to prevent sql injections
                string stm = @"SELECT * from songs WHERE id = @id";

                using var cmd = new MySqlCommand(stm, con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Prepare();
                using MySqlDataReader rdr = cmd.ExecuteReader();

                rdr.Read();
                return new Song()
                {
                    SongID = rdr.GetInt32(0),
                    SongTitle = rdr.IsDBNull(1) ? null : rdr.GetString(1),
                    SongTimestamp = rdr.IsDBNull(2) ? DateTime.MinValue : rdr.GetDateTime(2),
                    Deleted = rdr.IsDBNull(3) ? null : rdr.GetString(3),
                    Favorited = rdr.IsDBNull(4) ? null : rdr.GetString(4)
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