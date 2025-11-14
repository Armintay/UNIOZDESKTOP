using Microsoft.Data.SqlClient;

public static class DbConnection
{

    private const string ConnectionString = "Server=localhost;Database=HelpDeskDB;Trusted_Connection=True;TrustServerCertificate=True;";

    public static SqlConnection GetConnection()
    {
        return new SqlConnection(ConnectionString);
    }
}