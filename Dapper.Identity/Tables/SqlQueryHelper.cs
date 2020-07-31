using Dapper.Identity.Adapters;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Dapper.Identity.Tables
{
    public static class SqlQueryHelper
    {
        private static readonly ConcurrentDictionary<RuntimeTypeHandle, IEnumerable<PropertyInfo>> TypeProperties = new ConcurrentDictionary<RuntimeTypeHandle, IEnumerable<PropertyInfo>>();

        private static readonly ISqlAdapter DefaultAdapter = new SqlServerAdapter();
        private static readonly Dictionary<string, ISqlAdapter> AdapterDictionary
            = new Dictionary<string, ISqlAdapter>
            {
                ["SqlServerDbConnectionFactory"] = new SqlServerAdapter(),
                //["sqlceconnection"] = new SqlCeServerAdapter(),
                ["PostgreSqlDbConnectionFactory"] = new PostgresAdapter(),
                //["sqliteconnection"] = new SQLiteAdapter(),
                ["MySqlConnectionFactory"] = new MySqlAdapter(),
                ["FBConnectionFactory"] = new FbAdapter()
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


        public static List<PropertyInfo> TypePropertiesCache(Type type)
        {
            if (TypeProperties.TryGetValue(type.TypeHandle, out IEnumerable<PropertyInfo> pis))
            {
                return pis.ToList();
            }

            var properties = type.GetProperties().ToArray();
            TypeProperties[type.TypeHandle] = properties;
            return properties.ToList();
        }
    }
}
