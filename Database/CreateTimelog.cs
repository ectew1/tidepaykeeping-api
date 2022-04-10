using MySql.Data.MySqlClient;
using tidepaykeeping_api.Interfaces;
using tidepaykeeping_api.Models;

namespace tidepaykeeping_api.database
{
    public class CreateTimelog : ICreateTimelog
    {
        public void Create(Song song)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            //prepared statements to prevent sql injections
            string stm = @"INSERT INTO employee(Title, Timestamp, Deleted, Favorited) VALUES(@SongTitle, @SongTimestamp, @Deleted, @Favorited)";
            using var cmd = new MySqlCommand(stm, con);

            //now identifying what those @ really mean
            //cmd.Parameters.AddWithValue("@SongID", song.SongID);
            cmd.Parameters.AddWithValue("@SongTitle", song.SongTitle);
            cmd.Parameters.AddWithValue("@SongTimestamp", song.SongTimestamp);
            cmd.Parameters.AddWithValue("@Deleted", song.Deleted);
            cmd.Parameters.AddWithValue("@Favorited", song.Favorited);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}