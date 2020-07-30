using Dapper.Identity.Tables;
using Dapper.Identity.Tables.SqlServerTables;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper.Identity.Adapters
{
    public class SqlServerAdapter : ISqlAdapter
    {

        RolesTable<IdentityRole<string>, string, IdentityRoleClaim<string>> ISqlAdapter.RolesTable(IDbConnectionFactory dbConnectionFactory)
        {
            return new SqlServerRolesTable(dbConnectionFactory);
        }
    }
}
