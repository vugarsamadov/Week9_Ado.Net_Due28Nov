using System.Data;
using System.Data.SqlClient;

namespace Nov27Practice.Helpers
{
    public static class SqlHelper
    {
        private const string _connectionString = @"Server=localhost;Database=adonet;User Id=SA;Password=Vugar2003Vs$;";
        public static DataTable GetDatas(string query)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            DataTable dt = new DataTable();
            using SqlDataAdapter sda = new SqlDataAdapter(query, connection);
            sda.Fill(dt);
            connection.Close();
            return dt;
        }
        public static int Exec(string query)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            using SqlCommand command = new SqlCommand(query, connection);
            int result = command.ExecuteNonQuery();
            connection.Close();
            return result;
        }
    }
}
