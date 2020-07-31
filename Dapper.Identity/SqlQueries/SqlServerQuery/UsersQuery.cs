using Dapper.Identity.SqlQueries.Abstract;
using Dapper.Identity.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper.Identity.SqlQueries.SqlServerQuery
{
    

    public class UsersQuery : IUsersQuery
    {
        public string CreateSql<TUser>()
        {
            var userType = typeof(TUser);
            var tableInfo = SqlQueryHelper.GetTableNameAndSechma<TUser>("AspNetUsers");
            var colNames = SqlQueryHelper.GetColumnNames(userType);
            StringBuilder sqlStringBuilder = new StringBuilder("INSERT INTO ");
            sqlStringBuilder.AppendTableName(tableInfo.TableName, tableInfo.Sechma);
            sqlStringBuilder.Append("VALUES (");
            sqlStringBuilder.AppendColumnNames(colNames, true);
            sqlStringBuilder.Append(");");
            return sqlStringBuilder.ToString();
        }

        public string DeleteSql<TUser>()
        {
            var tableInfo = SqlQueryHelper.GetTableNameAndSechma<TUser>("AspNetUsers");
            StringBuilder sqlStringBuilder = new StringBuilder("DELETE FROM ");
            sqlStringBuilder.AppendTableName(tableInfo.TableName, tableInfo.Sechma);
            sqlStringBuilder.Append(" WHERE [Id] = @Id;");
            return sqlStringBuilder.ToString();
        }

        public string FindByIdSql<TUser>()
        {
            var tableInfo = SqlQueryHelper.GetTableNameAndSechma<TUser>("AspNetUsers");
            StringBuilder sqlStringBuilder = new StringBuilder("SELECT * FROM ");
            sqlStringBuilder.AppendTableName(tableInfo.TableName, tableInfo.Sechma);
            sqlStringBuilder.Append(" WHERE [Id] = @Id;");
            return sqlStringBuilder.ToString();
        }


        public string FindByNameSql<TUser>()
        {
            var tableInfo = SqlQueryHelper.GetTableNameAndSechma<TUser>("AspNetUsers");
            StringBuilder sqlStringBuilder = new StringBuilder("SELECT * FROM ");
            sqlStringBuilder.AppendTableName(tableInfo.TableName, tableInfo.Sechma);
            sqlStringBuilder.Append(" WHERE [NormalizedUserName] = @NormalizedUserName;");
            return sqlStringBuilder.ToString();
        }


        public string FindByEmailSql<TUser>()
        {
            var tableInfo = SqlQueryHelper.GetTableNameAndSechma<TUser>("AspNetUsers");
            StringBuilder sqlStringBuilder = new StringBuilder("SELECT * FROM ");
            sqlStringBuilder.AppendTableName(tableInfo.TableName, tableInfo.Sechma);
            sqlStringBuilder.Append(" WHERE [NormalizedEmail] = @NormalizedEmail;");
            return sqlStringBuilder.ToString();
        }

        public string UpdateUserSql<TUser>()
        {
            var tableInfo = SqlQueryHelper.GetTableNameAndSechma<TUser>("AspNetUsers");
            StringBuilder sqlStringBuilder = new StringBuilder("UPDATE ");
            sqlStringBuilder.AppendTableName(tableInfo.TableName, tableInfo.Sechma);
            sqlStringBuilder.Append(@"SET [UserName] = @UserName, 
                                          [NormalizedUserName] = @NormalizedUserName,
                                          [Email] = @Email, 
                                          [NormalizedEmail] = @NormalizedEmail,
                                          [EmailConfirmed] = @EmailConfirmed,
                                          [PasswordHash] = @PasswordHash,
                                          [SecurityStamp] = @SecurityStamp,
                                          [ConcurrencyStamp] = @ConcurrencyStamp,
                                          [PhoneNumber] = @PhoneNumber, 
                                          [PhoneNumberConfirmed] = @PhoneNumberConfirmed,
                                          [TwoFactorEnabled] = @TwoFactorEnabled,
                                          [LockoutEnd] = @LockoutEnd,
                                          [LockoutEnabled] = @LockoutEnabled, 
                                          [AccessFailedCount] = @AccessFailedCount 
                                     WHERE [Id] = @Id;");

            return sqlStringBuilder.ToString();
        }

        public string DeleteClaimsSql<TUserClaim>()
        {
            var tableInfo = SqlQueryHelper.GetTableNameAndSechma<TUserClaim>("AspNetUserClaims");
            StringBuilder sqlStringBuilder = new StringBuilder("DELETE FROM ");
            sqlStringBuilder.AppendTableName(tableInfo.TableName, tableInfo.Sechma);
            sqlStringBuilder.Append(" WHERE [UserId] = @UserId;");
            return sqlStringBuilder.ToString();
        }

        public string InsertClaimsSql<TUserClaim>()
        {
            var tableInfo = SqlQueryHelper.GetTableNameAndSechma<TUserClaim>("AspNetUserClaims");
            StringBuilder sqlStringBuilder = new StringBuilder("INSERT INTO ");
            sqlStringBuilder.AppendTableName(tableInfo.TableName, tableInfo.Sechma);
            sqlStringBuilder.Append(" (UserId, ClaimType, ClaimValue) VALUES (@UserId, @ClaimType, @ClaimValue);");
            return sqlStringBuilder.ToString();
        }

        public string DeleteRolesSql<TUserRole>()
        {
            var tableInfo = SqlQueryHelper.GetTableNameAndSechma<TUserRole>("AspNetUserRoles");
            StringBuilder sqlStringBuilder = new StringBuilder("DELETE FROM ");
            sqlStringBuilder.AppendTableName(tableInfo.TableName, tableInfo.Sechma);
            sqlStringBuilder.Append(" WHERE [UserId] = @UserId;");
            return sqlStringBuilder.ToString();
        }

        public string InsertRolesSql<TUserRole>()
        {
            var tableInfo = SqlQueryHelper.GetTableNameAndSechma<TUserRole>("AspNetUserRoles");
            StringBuilder sqlStringBuilder = new StringBuilder("INSERT INTO ");
            sqlStringBuilder.AppendTableName(tableInfo.TableName, tableInfo.Sechma);
            sqlStringBuilder.Append(" (UserId, RoleId) VALUES (@UserId, @RoleId);");
            return sqlStringBuilder.ToString();
        }

        public string DeleteLoginsSql<TUserLogin>()
        {
            var tableInfo = SqlQueryHelper.GetTableNameAndSechma<TUserLogin>("AspNetUserLogins");
            StringBuilder sqlStringBuilder = new StringBuilder("DELETE FROM ");
            sqlStringBuilder.AppendTableName(tableInfo.TableName, tableInfo.Sechma);
            sqlStringBuilder.Append(" WHERE [UserId] = @UserId;");
            return sqlStringBuilder.ToString();
        }


        public string InsertLoginsSql<TUserLogin>()
        {
            var tableInfo = SqlQueryHelper.GetTableNameAndSechma<TUserLogin>("AspNetUserLogins");
            StringBuilder sqlStringBuilder = new StringBuilder("INSERT INTO ");
            sqlStringBuilder.AppendTableName(tableInfo.TableName, tableInfo.Sechma);
            sqlStringBuilder.Append(@" (LoginProvider, ProviderKey, ProviderDisplayName, UserId) 
                                        VALUES (@LoginProvider, @ProviderKey, @ProviderDisplayName, @UserId);");
            return sqlStringBuilder.ToString();
        }

        public string DeleteTokenSql<TUserToken>()
        {
            var tableInfo = SqlQueryHelper.GetTableNameAndSechma<TUserToken>("AspNetUserTokens");
            StringBuilder sqlStringBuilder = new StringBuilder("DELETE FROM ");
            sqlStringBuilder.AppendTableName(tableInfo.TableName, tableInfo.Sechma);
            sqlStringBuilder.Append(" WHERE [UserId] = @UserId;");
            return sqlStringBuilder.ToString();
        }

        public string InsertTokenSql<TUserToken>()
        {
            var tableInfo = SqlQueryHelper.GetTableNameAndSechma<TUserToken>("AspNetUserTokens");
            StringBuilder sqlStringBuilder = new StringBuilder("INSERT INTO ");
            sqlStringBuilder.AppendTableName(tableInfo.TableName, tableInfo.Sechma);
            sqlStringBuilder.Append(@" (UserId, LoginProvider, Name, Value) VALUES (@UserId, @LoginProvider, @Name, @Value);");
            return sqlStringBuilder.ToString();
        }

        public string GetUsersInRoleSql<TUser, TUserRole, TRole>()
        {
            var userTableInfo = SqlQueryHelper.GetTableNameAndSechma<TUser>("AspNetUsers");
            var userRolesTableInfo = SqlQueryHelper.GetTableNameAndSechma<TUserRole>("AspNetUserRoles");
            var roleTableInfo = SqlQueryHelper.GetTableNameAndSechma<TUserRole>("AspNetRoles");
            StringBuilder sqlStringBuilder = new StringBuilder("SELECT * FROM ");
            sqlStringBuilder.AppendTableName(userTableInfo.TableName, userTableInfo.Sechma);
            sqlStringBuilder.Append(" AS [u] INNER JOIN ");
            sqlStringBuilder.AppendTableName(userRolesTableInfo.TableName, userRolesTableInfo.Sechma);
            sqlStringBuilder.Append(" AS [ur] ON [u].[Id] = [ur].[UserId] ");
            sqlStringBuilder.Append("INNER JOIN ");
            sqlStringBuilder.AppendTableName(roleTableInfo.TableName, roleTableInfo.Sechma);
            sqlStringBuilder.Append(" AS [r] ON [ur].[RoleId] = [r].[Id] WHERE [r].[Name] = @RoleName;");
            return sqlStringBuilder.ToString();
        }

        public string GetUsersForClaimSql<TUser, TUserClaim>()
        {
            var userTableInfo = SqlQueryHelper.GetTableNameAndSechma<TUser>("AspNetUsers");
            var userClaimTableInfo = SqlQueryHelper.GetTableNameAndSechma<TUserClaim>("AspNetUserClaims");
            StringBuilder sqlStringBuilder = new StringBuilder("SELECT * FROM ");
            sqlStringBuilder.AppendTableName(userTableInfo.TableName, userTableInfo.Sechma);
            sqlStringBuilder.Append(" AS [u] INNER JOIN ");
            sqlStringBuilder.AppendTableName(userClaimTableInfo.TableName, userClaimTableInfo.Sechma);
            sqlStringBuilder.Append(" AS [uc] ON [u].[Id] = [uc].[UserId] WHERE [uc].[ClaimType] = @ClaimType AND [uc].[ClaimValue] = @ClaimValue;");
            return sqlStringBuilder.ToString();
        }

    }
}
