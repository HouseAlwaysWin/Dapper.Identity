using Dapper.Identity.Attributes;
using Dapper.Identity.SqlQueries.Abstract;
using Dapper.Identity.Tables;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Dapper.Identity.SqlQueries.PostgreSqlQuery
{
    public class RolesQuery : IRolesQuery
    {
        public string CreateQuery<TRole>()
        {
            throw new NotImplementedException();
        }

        public string DeleteClaimsQuery<TRoleClaim>()
        {
            throw new NotImplementedException();
        }

        public string DeleteQuery<TRole>()
        {
            throw new NotImplementedException();
        }

        public string FindByIdQuery<TRole>()
        {
            throw new NotImplementedException();
        }

        public string FindByNameQuery<TRole>()
        {
            throw new NotImplementedException();
        }

        public string InsertClaimsQuery<TRoleClaim>()
        {
            throw new NotImplementedException();
        }

        public string UpdateRoleQuery<TRole>()
        {
            throw new NotImplementedException();
        }
    }
}
