﻿using Dapper.Identity.Abstract;
using Dapper.Identity.Adapters;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Dapper.Identity.Tables
{
    /// <summary>
    /// The default implementation of <see cref="IUsersTable{TUser, TKey, TUserClaim, TUserRole, TUserLogin, TUserToken}"/>.
    /// </summary>
    /// <typeparam name="TUser">The type representing a user.</typeparam>
    /// <typeparam name="TKey">The type of the primary key for a role and user.</typeparam>
    /// <typeparam name="TUserClaim">The type representing a claim.</typeparam>
    /// <typeparam name="TUserRole">The type representing a user role.</typeparam>
    /// <typeparam name="TUserLogin">The type representing a user external login.</typeparam>
    /// <typeparam name="TUserToken">The type representing a user token.</typeparam>
    public class UsersTable<TUser, TKey, TUserClaim, TUserRole, TUserLogin, TUserToken, TRole> :
        IdentityTable,
        IUsersTable<TUser, TKey, TUserClaim, TUserRole, TUserLogin, TUserToken, TRole>
        where TUser : IdentityUser<TKey>
        where TKey : IEquatable<TKey>
        where TUserClaim : IdentityUserClaim<TKey>, new()
        where TUserRole : IdentityUserRole<TKey>, new()
        where TUserLogin : IdentityUserLogin<TKey>, new()
        where TUserToken : IdentityUserToken<TKey>, new()
        where TRole : IdentityRole<TKey>, new()
    {
        private ISqlAdapter sqlAdapter;

        /// <summary>
        /// Creates a new instance of <see cref="UsersTable{TUser, TKey, TUserClaim, TUserRole, TUserLogin, TUserToken}"/>.
        /// </summary>
        /// <param name="dbConnectionFactory">A factory for creating instances of <see cref="IDbConnection"/>.</param>
        public UsersTable(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        {
            sqlAdapter = SqlQueryHelper.GetAdapter(dbConnectionFactory);
        }

        /// <inheritdoc/>
        public virtual async Task<bool> CreateAsync(TUser user)
        {
            //const string sql = "INSERT INTO [dbo].[AspNetUsers] " +
            //                   "VALUES (@Id, @UserName, @NormalizedUserName, @Email, @NormalizedEmail, @EmailConfirmed, @PasswordHash, @SecurityStamp, @ConcurrencyStamp, " +
            //                           "@PhoneNumber, @PhoneNumberConfirmed, @TwoFactorEnabled, @LockoutEnd, @LockoutEnabled, @AccessFailedCount);";

            string sql = sqlAdapter.UsersQuery.CreateSql<TUser>();
            var rowsInserted = await DbConnection.ExecuteAsync(sql, new
            {
                user.Id,
                user.UserName,
                user.NormalizedUserName,
                user.Email,
                user.NormalizedEmail,
                user.EmailConfirmed,
                user.PasswordHash,
                user.SecurityStamp,
                user.ConcurrencyStamp,
                user.PhoneNumber,
                user.PhoneNumberConfirmed,
                user.TwoFactorEnabled,
                user.LockoutEnd,
                user.LockoutEnabled,
                user.AccessFailedCount
            });
            return rowsInserted == 1;
        }

        /// <inheritdoc/>
        public virtual async Task<bool> DeleteAsync(TKey userId)
        {
            //const string sql = "DELETE " +
            //                   "FROM [dbo].[AspNetUsers] " +
            //                   "WHERE [Id] = @Id;";
            string sql = sqlAdapter.UsersQuery.DeleteSql<TUser>();
            var rowsDeleted = await DbConnection.ExecuteAsync(sql, new { Id = userId });
            return rowsDeleted == 1;
        }

        /// <inheritdoc/>
        public virtual async Task<TUser> FindByIdAsync(TKey userId)
        {
            //const string sql = "SELECT * " +
            //                   "FROM [dbo].[AspNetUsers] " +
            //                   "WHERE [Id] = @Id;";
            string sql = sqlAdapter.UsersQuery.FindByIdSql<TUser>();
            var user = await DbConnection.QuerySingleOrDefaultAsync<TUser>(sql, new { Id = userId });
            return user;
        }

        /// <inheritdoc/>
        public virtual async Task<TUser> FindByNameAsync(string normalizedUserName)
        {
            //const string sql = "SELECT * " +
            //                   "FROM [dbo].[AspNetUsers] " +
            //                   "WHERE [NormalizedUserName] = @NormalizedUserName;";
            string sql = sqlAdapter.UsersQuery.FindByNameSql<TUser>();
            var user = await DbConnection.QuerySingleOrDefaultAsync<TUser>(sql, new { NormalizedUserName = normalizedUserName });
            return user;
        }

        /// <inheritdoc/>
        public virtual async Task<TUser> FindByEmailAsync(string normalizedEmail)
        {
            //const string command = "SELECT * " +
            //                       "FROM [dbo].[AspNetUsers] " +
            //                       "WHERE [NormalizedEmail] = @NormalizedEmail;";
            string command = sqlAdapter.UsersQuery.FindByEmailSql<TUser>();
            var user = await DbConnection.QuerySingleOrDefaultAsync<TUser>(command, new { NormalizedEmail = normalizedEmail });
            return user;
        }

        /// <inheritdoc/>
        public virtual Task<bool> UpdateAsync(TUser user, IList<TUserClaim> claims, IList<TUserLogin> logins, IList<TUserToken> tokens)
        {
            return UpdateAsync(user, claims, null, logins, tokens);
        }

        /// <inheritdoc/>
        public virtual async Task<bool> UpdateAsync(TUser user, IList<TUserClaim> claims, IList<TUserRole> roles, IList<TUserLogin> logins, IList<TUserToken> tokens)
        {
            //const string updateUserSql =
            //    "UPDATE [dbo].[AspNetUsers] " +
            //    "SET [UserName] = @UserName, [NormalizedUserName] = @NormalizedUserName, [Email] = @Email, [NormalizedEmail] = @NormalizedEmail, [EmailConfirmed] = @EmailConfirmed, " +
            //        "[PasswordHash] = @PasswordHash, [SecurityStamp] = @SecurityStamp, [ConcurrencyStamp] = @ConcurrencyStamp, [PhoneNumber] = @PhoneNumber, " +
            //        "[PhoneNumberConfirmed] = @PhoneNumberConfirmed, [TwoFactorEnabled] = @TwoFactorEnabled, [LockoutEnd] = @LockoutEnd, [LockoutEnabled] = @LockoutEnabled, " +
            //        "[AccessFailedCount] = @AccessFailedCount " +
            //    "WHERE [Id] = @Id;";
            string updateUserSql = sqlAdapter.UsersQuery.UpdateUserSql<TUser>();
            using (var transaction = DbConnection.BeginTransaction())
            {
                await DbConnection.ExecuteAsync(updateUserSql, new
                {
                    user.UserName,
                    user.NormalizedUserName,
                    user.Email,
                    user.NormalizedEmail,
                    user.EmailConfirmed,
                    user.PasswordHash,
                    user.SecurityStamp,
                    user.ConcurrencyStamp,
                    user.PhoneNumber,
                    user.PhoneNumberConfirmed,
                    user.TwoFactorEnabled,
                    user.LockoutEnd,
                    user.LockoutEnabled,
                    user.AccessFailedCount,
                    user.Id
                }, transaction);
                if (claims?.Count() > 0)
                {
                    //const string deleteClaimsSql = "DELETE " +
                    //                               "FROM [dbo].[AspNetUserClaims] " +
                    //                               "WHERE [UserId] = @UserId;";
                    string deleteClaimsSql = sqlAdapter.UsersQuery.DeleteClaimsSql<TUserClaim>();
                    await DbConnection.ExecuteAsync(deleteClaimsSql, new { UserId = user.Id }, transaction);
                    //const string insertClaimsSql = "INSERT INTO [dbo].[AspNetUserClaims] (UserId, ClaimType, ClaimValue) " +
                    //                               "VALUES (@UserId, @ClaimType, @ClaimValue);";
                    string insertClaimsSql = sqlAdapter.UsersQuery.InsertClaimsSql<TUserClaim>();
                    await DbConnection.ExecuteAsync(insertClaimsSql, claims.Select(x => new
                    {
                        UserId = user.Id,
                        x.ClaimType,
                        x.ClaimValue
                    }), transaction);
                }
                if (roles?.Count() > 0)
                {
                    //const string deleteRolesSql = "DELETE " +
                    //                              "FROM [dbo].[AspNetUserRoles] " +
                    //                              "WHERE [UserId] = @UserId;";
                    string deleteRolesSql = sqlAdapter.UsersQuery.DeleteRolesSql<TUserRole>();
                    await DbConnection.ExecuteAsync(deleteRolesSql, new { UserId = user.Id }, transaction);
                    //const string insertRolesSql = "INSERT INTO [dbo].[AspNetUserRoles] (UserId, RoleId) " +
                    //                              "VALUES (@UserId, @RoleId);";
                    string insertRolesSql = sqlAdapter.UsersQuery.InsertRolesSql<TUserRole>();
                    await DbConnection.ExecuteAsync(insertRolesSql, roles.Select(x => new
                    {
                        UserId = user.Id,
                        x.RoleId
                    }), transaction);
                }
                if (logins?.Count() > 0)
                {
                    //const string deleteLoginsSql = "DELETE " +
                    //                               "FROM [dbo].[AspNetUserLogins] " +
                    //                               "WHERE [UserId] = @UserId;";
                    string deleteLoginsSql = sqlAdapter.UsersQuery.DeleteLoginsSql<TUserLogin>();
                    await DbConnection.ExecuteAsync(deleteLoginsSql, new { UserId = user.Id }, transaction);
                    //const string insertLoginsSql = "INSERT INTO [dbo].[AspNetUserLogins] (LoginProvider, ProviderKey, ProviderDisplayName, UserId) " +
                    //                               "VALUES (@LoginProvider, @ProviderKey, @ProviderDisplayName, @UserId);";
                    string insertLoginsSql = sqlAdapter.UsersQuery.InsertLoginsSql<TUserLogin>();

                    await DbConnection.ExecuteAsync(insertLoginsSql, logins.Select(x => new
                    {
                        x.LoginProvider,
                        x.ProviderKey,
                        x.ProviderDisplayName,
                        UserId = user.Id
                    }), transaction);
                }
                if (tokens?.Count() > 0)
                {
                    //const string deleteTokensSql = "DELETE " +
                    //                               "FROM [dbo].[AspNetUserTokens] " +
                    //                               "WHERE [UserId] = @UserId;";
                    string deleteTokensSql = sqlAdapter.UsersQuery.DeleteTokenSql<TUserToken>();
                    await DbConnection.ExecuteAsync(deleteTokensSql, new { UserId = user.Id }, transaction);
                    //const string insertTokensSql = "INSERT INTO [dbo].[AspNetUserTokens] (UserId, LoginProvider, Name, Value) " +
                    //                               "VALUES (@UserId, @LoginProvider, @Name, @Value);";
                    string insertTokensSql = sqlAdapter.UsersQuery.InsertTokenSql<TUserToken>();
                    await DbConnection.ExecuteAsync(insertTokensSql, tokens.Select(x => new
                    {
                        x.UserId,
                        x.LoginProvider,
                        x.Name,
                        x.Value
                    }), transaction);
                }
                try
                {
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
            return true;
        }

        /// <inheritdoc/>
        public virtual async Task<IEnumerable<TUser>> GetUsersInRoleAsync(string roleName)
        {
            //const string sql = "SELECT * " +
            //                   "FROM [dbo].[AspNetUsers] AS [u] " +
            //                   "INNER JOIN [dbo].[AspNetUserRoles] AS [ur] ON [u].[Id] = [ur].[UserId] " +
            //                   "INNER JOIN [dbo].[AspNetRoles] AS [r] ON [ur].[RoleId] = [r].[Id] " +
            //                   "WHERE [r].[Name] = @RoleName;";
            string sql = sqlAdapter.UsersQuery.GetUsersInRoleSql<TUser, TUserRole, TRole>();
            var users = await DbConnection.QueryAsync<TUser>(sql, new { RoleName = roleName });
            return users;
        }

        /// <inheritdoc/>
        public virtual async Task<IEnumerable<TUser>> GetUsersForClaimAsync(Claim claim)
        {
            //const string sql = "SELECT * " +
            //                       "FROM [dbo].[AspNetUsers] AS [u] " +
            //                       "INNER JOIN [dbo].[AspNetUserClaims] AS [uc] ON [u].[Id] = [uc].[UserId] " +
            //                       "WHERE [uc].[ClaimType] = @ClaimType AND [uc].[ClaimValue] = @ClaimValue;";
            string sql = sqlAdapter.UsersQuery.GetUsersForClaimSql<TUser, TUserClaim>();
            var users = await DbConnection.QueryAsync<TUser>(sql, new
            {
                ClaimType = claim.Type,
                ClaimValue = claim.Value
            });
            return users;
        }
    }
}