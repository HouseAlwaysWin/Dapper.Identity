using Dapper.Identity.SqlQueries.Abstract;
using Dapper.Identity.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper.Identity.SqlQueries.SqlServerQuery
{
    public class UserLoginsQuery : IUserLoginsQuery
    {
        public string GetLoginsSql<TUserLogin>()
        {
            var userClaimsTableInfo = SqlQueryHelper.GetTableNameAndSechma<TUserLogin>("AspNetUserClaims");
            StringBuilder sqlStringBuilder = new StringBuilder("SELECT * FROM ");
            sqlStringBuilder.AppendTableName(userClaimsTableInfo.TableName, userClaimsTableInfo.Sechma);
            sqlStringBuilder.Append(" WHERE [UserId] = @UserId;");
            return sqlStringBuilder.ToString();
        }

        public string FindByLoginSql<TUser, TUserLogin>()
        {
            var usersTableInfo = SqlQueryHelper.GetTableNameAndSechma<TUser>("AspNetUsers");
            var userLoginsTableInfo = SqlQueryHelper.GetTableNameAndSechma<TUserLogin>("AspNetUserLogins");
            StringBuilder sqlStringBuilder = new StringBuilder("SELECT [u].* FROM ");
            sqlStringBuilder.AppendTableName(usersTableInfo.TableName, usersTableInfo.Sechma);
            sqlStringBuilder.Append(" AS [u] INNER JOIN ");
            sqlStringBuilder.AppendTableName(userLoginsTableInfo.TableName, userLoginsTableInfo.Sechma);
            sqlStringBuilder.Append(" AS [ul] ON [ul].[UserId] = [u].[Id] WHERE [ul].[LoginProvider] = @LoginProvider AND [ul].[ProviderKey] = @ProviderKey;");
            return sqlStringBuilder.ToString();
        }

        public string FindUserLoginSql<TUserLogin>()
        {
            var userLoginsTableInfo = SqlQueryHelper.GetTableNameAndSechma<TUserLogin>("AspNetUserLogins");
            StringBuilder sqlStringBuilder = new StringBuilder("SELECT * FROM ");
            sqlStringBuilder.AppendTableName(userLoginsTableInfo.TableName, userLoginsTableInfo.Sechma);
            sqlStringBuilder.Append(" WHERE [LoginProvider] = @LoginProvider AND [ProviderKey] = @ProviderKey;");
            return sqlStringBuilder.ToString();
        }

        public string FindUserLoginWithUserIdSql<TUserLogin>()
        {
            var userLoginsTableInfo = SqlQueryHelper.GetTableNameAndSechma<TUserLogin>("AspNetUserLogins");
            StringBuilder sqlStringBuilder = new StringBuilder("SELECT * FROM ");
            sqlStringBuilder.AppendTableName(userLoginsTableInfo.TableName, userLoginsTableInfo.Sechma);
            sqlStringBuilder.Append(" WHERE [UserId] = @UserId AND [LoginProvider] = @LoginProvider AND [ProviderKey] = @ProviderKey;");
            return sqlStringBuilder.ToString();
        }

    }
}
