namespace tidepaykeeping_api
{
    public class ConnectionString
    {
        public string cs {get;set;}

        public ConnectionString()
        {
            string server = "wb39lt71kvkgdmw0.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            string database = "nxomlelz5v24ewkz";
            string port = "3306";
            string userName = "br96x32xwcmh48j4";
            string password = "r1hgqzya6wpd9wj8";

            cs = $@"server = {server};user = {userName};database = {database};port = {port};password = {password};";
        }
    }
}