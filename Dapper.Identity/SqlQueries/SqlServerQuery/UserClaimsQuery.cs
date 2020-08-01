using Dapper.Identity.SqlQueries.Abstract;
using Dapper.Identity.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper.Identity.SqlQueries.SqlServerQuery
{
    public class UserClaimsQuery : IUserClaimsQuery
    {
        public string GetClaimsSql<TUserClaim>()
        {
            var userClaimsTableInfo = SqlQueryHelper.GetTableNameAndSechma<TUserClaim>("AspNetUserClaims");
            StringBuilder sqlStringBuilder = new StringBuilder("SELECT [r].* FROM ");
            sqlStringBuilder.AppendTableName(userClaimsTableInfo.TableName, userClaimsTableInfo.Sechma);
            sqlStringBuilder.Append(" WHERE [UserId] = @UserId;");
            return sqlStringBuilder.ToString();
        }
    }
}
