using Dapper.Identity.Adapters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper.Identity.Tables
{
    public static class DbAdapterHelper
    {
        private static readonly ISqlAdapter DefaultAdapter = new SqlServerAdapter();
        private static readonly Dictionary<string, ISqlAdapter> AdapterDictionary
            = new Dictionary<string, ISqlAdapter>
            {
                ["SqlServerDbConnectionFactory"] = new SqlServerAdapter(),
                //["sqlceconnection"] = new SqlCeServerAdapter(),
                ["PostgreSqlDbConnectionFactory"] = new PostgresAdapter(),
                //["sqliteconnection"] = new SQLiteAdapter(),
                //["mysqlconnection"] = new MySqlAdapter(),
                //["fbconnection"] = new FbAdapter()
            };

        public delegate string GetDatabaseTypeDelegate(IDbConnectionFactory connection);
        public static GetDatabaseTypeDelegate GetDatabaseType;
        public static ISqlAdapter GetAdapter(IDbConnectionFactory connectionFactory)
        {
            var name = GetDatabaseType?.Invoke(connectionFactory)
                       ?? connectionFactory.GetType().Name;

            return AdapterDictionary.TryGetValue(name, out var adapter)
                ? adapter
                : DefaultAdapter;
        }
    }
}
