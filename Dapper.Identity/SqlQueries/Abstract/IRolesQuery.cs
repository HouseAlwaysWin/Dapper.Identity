using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper.Identity.SqlQueries.Abstract
{
    public interface IRolesQuery
    {
        string CreateQuery<TRole>(TRole role);

        string DeleteQuery<TKey>(TKey roleId);

        string FindByIdQuery<TKey>(TKey roleId);

        string FindByNameQuery<TKey>(string normalizedName);

        string UpdateRoleQuery<TRole, TRoleClaim>(TRole role, IList<TRoleClaim> claims = null);
        string DeleteClaimsQuery<TRole, TRoleClaim>(TRole role, IList<TRoleClaim> claims = null);
        string InsertClaimsQuery<TRole, TRoleClaim>(TRole role, IList<TRoleClaim> claims = null);

    }
}
