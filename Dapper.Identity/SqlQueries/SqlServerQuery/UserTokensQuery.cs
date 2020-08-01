using Dapper.Identity.SqlQueries.Abstract;
using Dapper.Identity.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper.Identity.SqlQueries.SqlServerQuery
{
    public class UserTokensQuery : IUserTokensQuery
    {

        public string GetTokensSql<TUserToken>()
        {
            var userTokensTableInfo = SqlQueryHelper.GetTableNameAndSechma<TUserToken>("AspNetUserTokens");
            StringBuilder sqlStringBuilder = new StringBuilder("SELECT * FROM ");
            sqlStringBuilder.AppendTableName(userTokensTableInfo.TableName, userTokensTableInfo.Sechma);
            sqlStringBuilder.Append(" WHERE [UserId] = @UserId;");
            return sqlStringBuilder.ToString();
        }

        public string FindTokenSql<TUserToken>()
        {
            var userTokensTableInfo = SqlQueryHelper.GetTableNameAndSechma<TUserToken>("AspNetUserTokens");
            StringBuilder sqlStringBuilder = new StringBuilder("SELECT * FROM ");
            sqlStringBuilder.AppendTableName(userTokensTableInfo.TableName, userTokensTableInfo.Sechma);
            sqlStringBuilder.Append(" WHERE [UserId] = @UserId AND [LoginProvider] = @LoginProvider AND [Name] = @Name;");
            return sqlStringBuilder.ToString();
        }
    }
}
