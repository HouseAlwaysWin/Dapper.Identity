using Dapper.Identity.SqlQueries.Abstract;
using Dapper.Identity.Tables;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper.Identity.Adapters
{
    public class SqlServerAdapter : ISqlAdapter
    {
        public IRolesQuery RolesQuery => new SqlQueries.SqlServerQuery.RolesQuery();

        public IUsersQuery UsersQuery => new SqlQueries.SqlServerQuery.UsersQuery();
    }
}
