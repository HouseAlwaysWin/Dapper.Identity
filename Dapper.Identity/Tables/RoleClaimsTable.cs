using Dapper.Identity.Abstract;
using Dapper.Identity.Adapters;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dapper.Identity.Tables
{
    /// <summary>
    /// The default implementation of <see cref="IRoleClaimsTable{TKey, TRoleClaim}"/>.
    /// </summary>
    /// <typeparam name="TKey">The type of the primary key for a role.</typeparam>
    /// <typeparam name="TRoleClaim">The type of the class representing a role claim.</typeparam>
    public class RoleClaimsTable<TKey, TRoleClaim> :
        IdentityTable,
        IRoleClaimsTable<TKey, TRoleClaim>
        where TKey : IEquatable<TKey>
        where TRoleClaim : IdentityRoleClaim<TKey>, new()
    {
        private ISqlAdapter sqlAdapter;

        /// <summary>
        /// Creates a new instance of <see cref="RoleClaimsTable{TKey, TRoleClaim}"/>.
        /// </summary>
        /// <param name="dbConnectionFactory">A factory for creating instances of <see cref="IDbConnection"/>.</param>
        public RoleClaimsTable(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        {
            sqlAdapter = SqlQueryHelper.GetAdapter(dbConnectionFactory);
        }

        /// <inheritdoc/>
        public virtual async Task<IEnumerable<TRoleClaim>> GetClaimsAsync(TKey roleId)
        {
            //const string sql = "SELECT * " +
            //    "FROM [dbo].[AspNetRoleClaims] " +
            //    "WHERE [RoleId] = @RoleId;";
            string sql = sqlAdapter.RoleClaimsQuery.GetClaims<TRoleClaim>();
            var roleClaims = await DbConnection.QueryAsync<TRoleClaim>(sql, new { RoleId = roleId });
            return roleClaims;
        }
    }
}