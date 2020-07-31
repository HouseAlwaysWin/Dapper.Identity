using Dapper.Identity.Attributes;
using Dapper.Identity.SqlQueries.Abstract;
using Dapper.Identity.Tables;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Dapper.Identity.SqlQueries.PostgreSqlQuery
{
    public class RolesQuery : IRolesQuery
    {
        public string CreateQuery<TRole, TKey>(TRole role)
            where TRole : IdentityRole<TKey>
            where TKey : IEquatable<TKey>
        {
            var roleType = typeof(TRole);
            var tableInfo = SqlQueryHelper.GetTableNameAndSechma<TRole>();
            List<string> colNames = SqlQueryHelper.GetColumnNames(roleType);

            StringBuilder sqlStringBuilder = new StringBuilder("INSERT INTO ");
            SqlQueryHelper.AppendTableName(ref sqlStringBuilder, tableInfo.TableName, tableInfo.Sechma);
            sqlStringBuilder.Append(" VALUES (");
            SqlQueryHelper.AppendColumnNamesParams(ref sqlStringBuilder, colNames);
            sqlStringBuilder.Append(");");

            return sqlStringBuilder.ToString();
        }

        public string CreateQuery<TRole>(TRole role)
        {
            throw new NotImplementedException();
        }

        public string DeleteClaimsQuery<TRole, TRoleClaim>(TRole role, IList<TRoleClaim> claims = null)
        {
            throw new NotImplementedException();
        }

        public string DeleteQuery<TKey>(TKey roleId)
        {
            throw new NotImplementedException();
        }

        public string FindByIdQuery<TKey>(TKey roleId)
        {
            throw new NotImplementedException();
        }

        public string FindByNameQuery<TKey>(string normalizedName)
        {
            throw new NotImplementedException();
        }

        public string InsertClaimsQuery<TRole, TRoleClaim>(TRole role, IList<TRoleClaim> claims = null)
        {
            throw new NotImplementedException();
        }

        public string UpdateAsync<TRole, TRoleClaim>(TRole role, IList<TRoleClaim> claims = null)
        {
            throw new NotImplementedException();
        }

        public string UpdateRoleQuery<TRole, TRoleClaim>(TRole role, IList<TRoleClaim> claims = null)
        {
            throw new NotImplementedException();
        }
    }
}
