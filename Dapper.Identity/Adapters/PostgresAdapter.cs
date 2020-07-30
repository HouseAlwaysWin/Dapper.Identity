using Dapper.Identity.Tables;
using Dapper.Identity.Tables.PostgreSqlTables;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper.Identity.Adapters
{
    public class PostgresAdapter : ISqlAdapter
    {
        public RolesTable<IdentityRole<string>, string, IdentityRoleClaim<string>> RolesTable(IDbConnectionFactory dbConnectionFactory)
        {
            return new PostgreSqlRolesTable(dbConnectionFactory);
        }
    }
}
