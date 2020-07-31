using Dapper.Identity.Adapters;
using Dapper.Identity.Attributes;
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

        public static (string TableName, string Sechma) GetTableNameAndSechma<T>()
        {
            var tableNameAttr = typeof(T).GetCustomAttributes(typeof(TableNameAttribute), true).FirstOrDefault() as TableNameAttribute;
            string tableName = "AspNetRoles", sechma = "dbo";
            if (tableNameAttr != null)
            {
                tableName = string.IsNullOrWhiteSpace(tableNameAttr.TableName) ? tableName : tableNameAttr.TableName;
                sechma = string.IsNullOrWhiteSpace(tableNameAttr.Schema) ? sechma : tableNameAttr.TableName;
            }

            return (tableName, sechma);
        }

        public static List<string> GetColumnNames(Type type)
        {
            var allProperties = TypePropertiesCache(type);
            List<string> colNames = new List<string>();
            foreach (var prop in allProperties)
            {
                var colAttr = prop.GetCustomAttribute<ColumnNameAttribute>();
                if (colAttr != null)
                {
                    var name = string.IsNullOrWhiteSpace(colAttr.Name) ? prop.Name : colAttr.Name;
                    colNames.Add(name);
                }
            }
            return colNames;
        }

        public static void AppendTableName(ref StringBuilder sqlStringBuilder, string tableName, string sechema)
        {
            sqlStringBuilder.Append(" [");
            sqlStringBuilder.Append(sechema);
            sqlStringBuilder.Append("].");
            sqlStringBuilder.Append("[");
            sqlStringBuilder.Append(tableName);
            sqlStringBuilder.Append("] ");
        }

        public static void AppendColumnNamesParams(ref StringBuilder sqlStringBuilder, List<string> colNames)
        {
            for (int i = 0; i < colNames.Count; i++)
            {
                var name = colNames[i];
                sqlStringBuilder.Append("@");
                sqlStringBuilder.Append(name);
                if (i == (colNames.Count - 1))
                {
                    sqlStringBuilder.Append(",");
                }
            }
        }

    }
}
