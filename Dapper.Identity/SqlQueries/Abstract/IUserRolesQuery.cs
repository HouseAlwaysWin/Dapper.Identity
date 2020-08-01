namespace Dapper.Identity.SqlQueries.Abstract
{
    public interface IUserRolesQuery
    {
        string FindUserRoleSql<TRole>();
        string GetRolesSql<TRole, TUserRole>();
    }
}