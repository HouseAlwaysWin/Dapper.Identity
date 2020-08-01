namespace Dapper.Identity.SqlQueries.Abstract
{
    public interface IUserTokensQuery
    {
        string FindTokenSql<TUserToken>();
        string GetTokensSql<TUserToken>();
    }
}