using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper.Identity.SqlQueries.Abstract
{
    public interface IRolesQuery
    {
        string CreateSql<TRole>();
        string DeleteClaimsSql<TRoleClaim>();
        string DeleteSql<TRole>();
        string FindByIdSql<TRole>();
        string FindByNameSql<TRole>();
        string InsertClaimsSql<TRoleClaim>();
        string UpdateRoleSql<TRole>();
    }
}
