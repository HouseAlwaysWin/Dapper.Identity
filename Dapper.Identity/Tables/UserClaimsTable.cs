using Dapper.Identity.Abstract;
using Dapper.Identity.Adapters;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dapper.Identity.Tables
{
    /// <summary>
    /// The default implementation of <see cref="IUserClaimsTable{TKey, TUserClaim}"/>.
    /// </summary>
    /// <typeparam name="TKey">The type of the primary key for a user.</typeparam>
    /// <typeparam name="TUserClaim">The type representing a claim.</typeparam>
    public class UserClaimsTable<TKey, TUserClaim> :
        IdentityTable,
        IUserClaimsTable<TKey, TUserClaim>
        where TKey : IEquatable<TKey>
        where TUserClaim : IdentityUserClaim<TKey>, new()
    {
        private ISqlAdapter sqlAdapter;

        /// <summary>
        /// Creates a new instance of <see cref="UserClaimsTable{TKey, TUserClaim}"/>.
        /// </summary>
        /// <param name="dbConnectionFactory">A factory for creating instances of <see cref="IDbConnection"/>.</param>
        public UserClaimsTable(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        {
            sqlAdapter = SqlQueryHelper.GetAdapter(dbConnectionFactory);
        }

        /// <inheritdoc/>
        public virtual async Task<IEnumerable<TUserClaim>> GetClaimsAsync(TKey userId)
        {
            //const string sql = "SELECT * " +
            //                   "FROM [dbo].[AspNetUserClaims] " +
            //                   "WHERE [UserId] = @UserId;";
            string sql = sqlAdapter.UserClaimsQuery.GetClaimsSql<TUserClaim>();
            var userClaims = await DbConnection.QueryAsync<TUserClaim>(sql, new { UserId = userId });
            return userClaims;
        }
    }
}