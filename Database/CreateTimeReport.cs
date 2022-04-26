using MySql.Data.MySqlClient;
using tidepaykeeping_api.Interfaces;
using tidepaykeeping_api.Models;

namespace tidepaykeeping_api.Database
{
    public class CreateTimeReport
    {
        public static void DropTimeReportTable() //won't actually use this
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"DROP TABLE IF EXISTS timekeepingreport";
            

            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();
            //System.Console.WriteLine("dropped table");
        }
        public static void CreateTimeReportTable() //table is already created, but this is how I did it at the beginning
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"create table timekeepingreport
                        as
                        SELECT
                            empID,
                            DATE(clockIn) AS dayofwork,
                            DATE_FORMAT(TIME(clockIn), '%r') AS clockinHour,
                            DATE_FORMAT(TIME(clockOut), '%r') AS clockoutHour,
                            CONVERT( TIMESTAMPDIFF(MINUTE, clockIn, clockOut) / 60 , DECIMAL (3 , 2 )) AS total
                        FROM
                            timekeeping;";

            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();
            //System.Console.WriteLine("created table");
        }
    }
}