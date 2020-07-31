using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper.Identity.SqlQueries.Abstract
{
    public interface IUsersQuery
    {
        string CreateSql<TUser>();
        string DeleteClaimsSql<TUserClaim>();
        string DeleteLoginsSql<TUserLogin>();
        string DeleteRolesSql<TUserRole>();
        string DeleteTokenSql<TUserToken>();
        string DeleteSql<TUser>();
        string FindByEmailSql<TUser>();
        string FindByIdSql<TUser>();
        string FindByNameSql<TUser>();
        string GetUsersForClaimSql<TUser, TUserClaim>();
        string GetUsersInRoleSql<TUser, TUserRole, TRole>();
        string InsertClaimsSql<TUserClaim>();
        string InsertLoginsSql<TUserLogin>();
        string InsertRolesSql<TUserRole>();
        string InsertTokenSql<TUserToken>();
        string UpdateUserSql<TUser>();
    }
}
