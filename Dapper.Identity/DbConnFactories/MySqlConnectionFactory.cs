using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Dapper.Identity.DbConnFactories
{
    public class MySqlConnectionFactory : IDbConnectionFactory
    {
        public string ConnectionString { get; set; }

        public IDbConnection Create()
        {
            var sqlConnection = new MySqlConnection(ConnectionString);
            sqlConnection.Open();
            return sqlConnection;
        }
    }
}
