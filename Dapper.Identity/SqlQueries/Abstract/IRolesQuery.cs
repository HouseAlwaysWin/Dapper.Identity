using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper.Identity.SqlQueries.Abstract
{
    public interface IRolesQuery
    {
        string CreateQuery<TRole>();

        string DeleteQuery<TRole>();

        string FindByIdQuery<TRole>();

        string FindByNameQuery<TRole>();

        string UpdateRoleQuery<TRole>();
        string DeleteClaimsQuery<TRoleClaim>();
        string InsertClaimsQuery<TRoleClaim>();

    }
}
