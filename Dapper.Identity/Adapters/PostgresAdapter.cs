﻿using Dapper.Identity.SqlQueries;
using Dapper.Identity.SqlQueries.Abstract;
using Dapper.Identity.Tables;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper.Identity.Adapters
{
    public class PostgresAdapter : ISqlAdapter
    {
        public IRolesQuery RolesQuery => throw new NotImplementedException();

        public IUsersQuery UsersQuery => throw new NotImplementedException();

        public IUserRolesQuery UserRolesQuery => throw new NotImplementedException();

        public IUserClaimsQuery UserClaimsQuery => throw new NotImplementedException();

        public IUserLoginsQuery UserLoginsQuery => throw new NotImplementedException();

        public IRoleClaimsQuery RoleClaimsQuery => throw new NotImplementedException();

        public IUserTokensQuery UserTokensQuery => throw new NotImplementedException();
    }
}
