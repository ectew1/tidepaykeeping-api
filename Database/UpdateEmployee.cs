using System;
using MySql.Data.MySqlClient;
using tidepaykeeping_api.Interfaces;
using tidepaykeeping_api.Models;

namespace tidepaykeeping_api.Database
{
    public class UpdateEmployee : IUpdateEmployee
    {
        public void Update(Employee employee)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"UPDATE employee SET Title = @SongTitle, Timestamp = @SongTimestamp, Deleted = @Deleted, Favorited = @Favorited WHERE id = @id";
            using var cmd = new MySqlCommand(stm, con);

            //now identifying what those @ really mean
            cmd.Parameters.AddWithValue("@id", song.SongID);
            cmd.Parameters.AddWithValue("@SongTitle", song.SongTitle);
            cmd.Parameters.AddWithValue("@SongTimestamp", song.SongTimestamp);
            cmd.Parameters.AddWithValue("@Deleted", song.Deleted);
            cmd.Parameters.AddWithValue("@Favorited", song.Favorited);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}