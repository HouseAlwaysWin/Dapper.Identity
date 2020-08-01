namespace Dapper.Identity.SqlQueries.Abstract
{
    public interface IRoleClaimsQuery
    {
        string GetClaims<TRoleClaim>();
    }
}