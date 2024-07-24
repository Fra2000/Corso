namespace progettoweek2.DAO
{
    using System.Data.SqlClient;

    public abstract class DaoBase
    {
        protected string ConnectionString { get; }

        protected DaoBase(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
