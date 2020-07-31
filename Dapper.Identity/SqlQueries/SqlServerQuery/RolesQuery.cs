using Dapper.Identity.SqlQueries.Abstract;
using Dapper.Identity.Tables;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper.Identity.SqlQueries.SqlServerQuery
{
    public class RolesQuery : IRolesQuery
    {
        public string CreateQuery<TRole>()
        {
            var roleType = typeof(TRole);
            var tableInfo = SqlQueryHelper.GetTableNameAndSechma<TRole>();
            List<string> colNames = SqlQueryHelper.GetColumnNames(roleType);

            StringBuilder sqlStringBuilder = new StringBuilder("INSERT INTO ");
            sqlStringBuilder.AppendTableName(tableInfo.TableName, tableInfo.Sechma);
            sqlStringBuilder.Append(" VALUES (");
            sqlStringBuilder.AppendColumnNames(colNames, true);
            sqlStringBuilder.Append(");");

            return sqlStringBuilder.ToString();
        }

        public string DeleteQuery<TRole>()
        {
            var tableInfo = SqlQueryHelper.GetTableNameAndSechma<TRole>();
            StringBuilder sqlStringBuilder = new StringBuilder("DELETE FROM ");
            sqlStringBuilder.AppendTableName(tableInfo.TableName, tableInfo.Sechma);
            sqlStringBuilder.Append(" WHERE [Id] = @Id");
            return sqlStringBuilder.ToString();
        }

        public string FindByIdQuery<TRole>()
        {
            var tableInfo = SqlQueryHelper.GetTableNameAndSechma<TRole>();

            StringBuilder sqlStringBuilder = new StringBuilder("SELECT * FROM ");
            sqlStringBuilder.AppendTableName(tableInfo.TableName, tableInfo.Sechma);
            sqlStringBuilder.Append(" WHERE [Id] = @Id");
            return sqlStringBuilder.ToString();

        }

        public string FindByNameQuery<TRole>()
        {
            var tableInfo = SqlQueryHelper.GetTableNameAndSechma<TRole>();

            StringBuilder sqlStringBuilder = new StringBuilder("SELECT * FROM ");
            sqlStringBuilder.AppendTableName(tableInfo.TableName, tableInfo.Sechma);
            sqlStringBuilder.Append(" WHERE [NormalizedName] = @NormalizedName;");
            return sqlStringBuilder.ToString();
        }

        public string InsertClaimsQuery<TRoleClaim>()
        {
            var tableInfo = SqlQueryHelper.GetTableNameAndSechma<TRoleClaim>();
            StringBuilder sqlStringBuilder = new StringBuilder("INSERT INTO ");
            sqlStringBuilder.AppendTableName(tableInfo.TableName, tableInfo.Sechma);
            sqlStringBuilder.Append("(RoleId, ClaimType, ClaimValue) VALUES (@RoleId, @ClaimType, @ClaimValue);");
            return sqlStringBuilder.ToString();
        }

        public string DeleteClaimsQuery<TRoleClaim>()
        {
            var tableInfo = SqlQueryHelper.GetTableNameAndSechma<TRoleClaim>();
            StringBuilder sqlStringBuilder = new StringBuilder("DELETE FROM ");
            sqlStringBuilder.AppendTableName(tableInfo.TableName, tableInfo.Sechma);
            sqlStringBuilder.Append(" WHERE [RoleId] = @RoleId;");
            return sqlStringBuilder.ToString();
        }

        public string UpdateRoleQuery<TRole>()
        {
            var tableInfo = SqlQueryHelper.GetTableNameAndSechma<TRole>();
            StringBuilder sqlStringBuilder = new StringBuilder("UPDATE ");
            sqlStringBuilder.AppendTableName(tableInfo.TableName, tableInfo.Sechma);
            sqlStringBuilder.Append("SET [Name] = @Name, [NormalizedName] = @NormalizedName, [ConcurrencyStamp] = @ConcurrencyStamp WHERE [Id] = @Id;");
            return sqlStringBuilder.ToString();
        }
    }
}
