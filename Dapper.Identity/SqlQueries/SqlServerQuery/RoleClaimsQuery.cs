using Dapper.Identity.SqlQueries.Abstract;
using Dapper.Identity.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper.Identity.SqlQueries.SqlServerQuery
{
    public class RoleClaimsQuery : IRoleClaimsQuery
    {
        public string GetClaims<TRoleClaim>()
        {
            var roleClaimsTableInfo = SqlQueryHelper.GetTableNameAndSechma<TRoleClaim>("AspNetRoleClaims");
            StringBuilder sqlStringBuilder = new StringBuilder("SELECT * FROM ");
            sqlStringBuilder.AppendTableName(roleClaimsTableInfo.TableName, roleClaimsTableInfo.Sechma);
            sqlStringBuilder.Append(" WHERE [RoleId] = @RoleId;");
            return sqlStringBuilder.ToString();
        }
    }
}
