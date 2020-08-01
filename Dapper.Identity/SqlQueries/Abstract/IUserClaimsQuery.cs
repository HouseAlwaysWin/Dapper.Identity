namespace Dapper.Identity.SqlQueries.Abstract
{
    public interface IUserClaimsQuery
    {
        string GetClaimsSql<TUserClaim>();
    }
}