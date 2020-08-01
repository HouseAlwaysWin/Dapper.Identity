using Dapper.Identity.SqlQueries.Abstract;
using Dapper.Identity.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper.Identity.SqlQueries.SqlServerQuery
{
    public class UserRolesQuery : IUserRolesQuery
    {
        public string GetRolesSql<TRole, TUserRole>()
        {
            var roleTableInfo = SqlQueryHelper.GetTableNameAndSechma<TRole>("AspNetRoles");
            var userRolesTableInfo = SqlQueryHelper.GetTableNameAndSechma<TRole>("AspNetUserRoles");
            StringBuilder sqlStringBuilder = new StringBuilder("SELECT [r].* FROM ");
            sqlStringBuilder.AppendTableName(roleTableInfo.TableName, roleTableInfo.Sechma);
            sqlStringBuilder.Append(" INNER JOIN ");
            sqlStringBuilder.AppendTableName(userRolesTableInfo.TableName, userRolesTableInfo.Sechma);
            sqlStringBuilder.Append(" AS [ur] ON [ur].[RoleId] = [r].[Id] WHERE [ur].[UserId] = @UserId;");
            return sqlStringBuilder.ToString();
        }

        public string FindUserRoleSql<TRole>()
        {
            var userRolesTableInfo = SqlQueryHelper.GetTableNameAndSechma<TRole>("AspNetUserRoles");
            StringBuilder sqlStringBuilder = new StringBuilder("SELECT * FROM ");
            sqlStringBuilder.AppendTableName(userRolesTableInfo.TableName, userRolesTableInfo.Sechma);
            sqlStringBuilder.Append("WHERE [UserId] = @UserId AND [RoleId] = @RoleId;");
            return sqlStringBuilder.ToString();
        }
    }
}
