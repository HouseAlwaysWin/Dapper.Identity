using Dapper.Identity.SqlQueries.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper.Identity.Adapters
{
    public class MySqlAdapter : ISqlAdapter
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
