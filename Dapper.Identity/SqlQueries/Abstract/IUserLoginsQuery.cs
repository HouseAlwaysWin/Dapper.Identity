namespace Dapper.Identity.SqlQueries.Abstract
{
    public interface IUserLoginsQuery
    {
        string FindByLoginSql<TUser, TUserLogin>();
        string FindUserLoginSql<TUserLogin>();
        string FindUserLoginWithUserIdSql<TUserLogin>();
        string GetLoginsSql<TUserLogin>();
    }
}