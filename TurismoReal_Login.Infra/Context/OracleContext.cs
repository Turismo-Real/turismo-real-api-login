using Oracle.ManagedDataAccess.Client;
using System;

namespace TurismoReal_Login.Infra.Context
{
    public class OracleContext
    {
        protected readonly string connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION");
        private readonly OracleConnection connection;

        public OracleContext()
        {
            connection = new OracleConnection(connectionString);
        }

        public OracleConnection GetConnection()
        {
            return this.connection;
        }

        public void OpenConnection()
        {
            this.connection.Open();
        }

        public void CloseConnection()
        {
            this.connection.Close();
        }

    }
}
