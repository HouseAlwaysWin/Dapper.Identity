using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Dapper.Identity.DbConnFactories
{
    public class PostgreSqlDbConnectionFactory : IDbConnectionFactory
    {
        /// <summary>
        /// The connection string to use for connecting to Microsoft SQL Server.
        /// </summary>
        public string ConnectionString { get; set; }

        public IDbConnection Create()
        {
            var sqlConnection = new NpgsqlConnection(ConnectionString);
            sqlConnection.Open();
            return sqlConnection;
        }
    }
}
