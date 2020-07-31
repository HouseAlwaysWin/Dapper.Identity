using Dapper.Identity.SqlQueries.Abstract;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper.Identity.SqlQueries.SqlServerQuery
{
    public class RolesQuery : IRolesQuery
    {
        public string CreateQuery<TRole, TKey>(TRole role)
            where TRole : IdentityRole<TKey>
            where TKey : IEquatable<TKey>
        {
            const string sql = "INSERT INTO [dbo].[AspNetRoles] " +
                            "VALUES (@Id, @Name, @NormalizedName, @ConcurrencyStamp);";
            return sql;
        }

        public string CreateQuery<TRole>(TRole role)
        {
            throw new NotImplementedException();
        }

        public string DeleteClaimsQuery<TRole, TRoleClaim>(TRole role, IList<TRoleClaim> claims = null)
        {
            throw new NotImplementedException();
        }

        public string DeleteQuery<TKey>(TKey roleId)
        {
            throw new NotImplementedException();
        }

        public string FindByIdQuery<TKey>(TKey roleId)
        {
            throw new NotImplementedException();
        }

        public string FindByNameQuery<TKey>(string normalizedName)
        {
            throw new NotImplementedException();
        }

        public string InsertClaimsQuery<TRole, TRoleClaim>(TRole role, IList<TRoleClaim> claims = null)
        {
            throw new NotImplementedException();
        }

        public string UpdateAsync<TRole, TRoleClaim>(TRole role, IList<TRoleClaim> claims = null)
        {
            throw new NotImplementedException();
        }

        public string UpdateRoleQuery<TRole, TRoleClaim>(TRole role, IList<TRoleClaim> claims = null)
        {
            throw new NotImplementedException();
        }
    }
}
