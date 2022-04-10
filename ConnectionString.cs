namespace tidepaykeeping_api
{
    public class ConnectionString
    {
        public string cs {get;set;}

        public ConnectionString()
        {
            string server = "wb39lt71kvkgdmw0.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            string database = "cky8s1onev8k1aus";
            string port = "3306";
            string userName = "qfy4tdylnzszpvmk";
            string password = "r6n82pis73prqwot";

            cs = $@"server = {server};user = {userName};database = {database};port = {port};password = {password};";
        }
    }
}