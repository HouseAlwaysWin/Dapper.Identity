using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper.Identity.Tables.SqlServerTables
{
    public class SqlServerRolesTable : RolesTable<IdentityRole<string>, string, IdentityRoleClaim<string>>
    {
        public SqlServerRolesTable(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        {
        }
    }
}
