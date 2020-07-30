using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Identity.Tables.PostgreSqlTables
{
    public class PostgreSqlRolesTable : RolesTable<IdentityRole<string>, string, IdentityRoleClaim<string>>
    {
        public PostgreSqlRolesTable(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        {
        }

        public override async Task<bool> CreateAsync(IdentityRole<string> role)
        {
            const string sql = @"INSERT INTO dbo.AspNetRoles (Id,Name,NormalizedName,ConcurrencyStamp)
                               VALUES (@Id, @Name, @NormalizedName, @ConcurrencyStamp);";
            var rowsInserted = await DbConnection.ExecuteAsync(sql, new
            {
                role.Id,
                role.Name,
                role.NormalizedName,
                role.ConcurrencyStamp,
            });
            return rowsInserted == 1;
        }

        public override async Task<bool> UpdateAsync(IdentityRole<string> role, IList<IdentityRoleClaim<string>> claims = null)
        {
            const string updateRoleSql = @"UPDATE dbo.AspNetRoles 
                                         SET Name = @Name, NormalizedName = @NormalizedName, ConcurrencyStamp = @ConcurrencyStamp, Description = @Description 
                                         WHERE Id = @Id;";
            using (var transaction = DbConnection.BeginTransaction())
            {
                await DbConnection.ExecuteAsync(updateRoleSql, new
                {
                    role.Name,
                    role.NormalizedName,
                    role.ConcurrencyStamp,
                    role.Id
                }, transaction);
                if (claims?.Count() > 0)
                {
                    const string deleteClaimsSql = @"DELETE  
                                                   FROM dbo.AspNetRoleClaims 
                                                   WHERE RoleId = @RoleId;";
                    await DbConnection.ExecuteAsync(deleteClaimsSql, new
                    {
                        RoleId = role.Id
                    }, transaction);
                    const string insertClaimsSql = @"INSERT INTO [dbo].[AspNetRoleClaims] (RoleId, ClaimType, ClaimValue) 
                                                   VALUES (@RoleId, @ClaimType, @ClaimValue);";
                    await DbConnection.ExecuteAsync(insertClaimsSql, claims.Select(x => new
                    {
                        RoleId = role.Id,
                        x.ClaimType,
                        x.ClaimValue
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
    }
}
