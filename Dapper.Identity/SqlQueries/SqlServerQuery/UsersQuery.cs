using Dapper.Identity.SqlQueries.Abstract;
using Dapper.Identity.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper.Identity.SqlQueries.SqlServerQuery
{
    public class UsersQuery : IUsersQuery
    {
        public string CreateQuery<TUser>()
        {
            var userType = typeof(TUser);
            var tableInfo = SqlQueryHelper.GetTableNameAndSechma<TUser>();
            var colNames = SqlQueryHelper.GetColumnNames(userType);
            StringBuilder sqlStringBuilder = new StringBuilder("INSERT INTO ");
            sqlStringBuilder.AppendTableName(tableInfo.TableName, tableInfo.Sechma);
            sqlStringBuilder.Append("VALUES (");
            sqlStringBuilder.AppendColumnNames(colNames, true);
            sqlStringBuilder.Append(");");
            return sqlStringBuilder.ToString();
        }

        public string DeleteQuery<TUser>()
        {
            var tableInfo = SqlQueryHelper.GetTableNameAndSechma<TUser>();
            StringBuilder sqlStringBuilder = new StringBuilder("DELETE FROM ");
            sqlStringBuilder.AppendTableName(tableInfo.TableName, tableInfo.Sechma);
            sqlStringBuilder.Append(" WHERE [Id] = @Id;");
            return sqlStringBuilder.ToString();
        }

        public string FindByIdQuery<TUser>()
        {
            var tableInfo = SqlQueryHelper.GetTableNameAndSechma<TUser>();
            StringBuilder sqlStringBuilder = new StringBuilder("SELECT * FROM ");
            sqlStringBuilder.AppendTableName(tableInfo.TableName, tableInfo.Sechma);
            sqlStringBuilder.Append(" WHERE [Id] = @Id;");
            return sqlStringBuilder.ToString();
        }


        public string FindByNameQuery<TUser>()
        {
            var tableInfo = SqlQueryHelper.GetTableNameAndSechma<TUser>();
            StringBuilder sqlStringBuilder = new StringBuilder("SELECT * FROM ");
            sqlStringBuilder.AppendTableName(tableInfo.TableName, tableInfo.Sechma);
            sqlStringBuilder.Append(" WHERE [NormalizedUserName] = @NormalizedUserName;");
            return sqlStringBuilder.ToString();
        }


        public string FindByEmailQuery<TUser>()
        {
            var tableInfo = SqlQueryHelper.GetTableNameAndSechma<TUser>();
            StringBuilder sqlStringBuilder = new StringBuilder("SELECT * FROM ");
            sqlStringBuilder.AppendTableName(tableInfo.TableName, tableInfo.Sechma);
            sqlStringBuilder.Append(" WHERE [NormalizedEmail] = @NormalizedEmail;");
            return sqlStringBuilder.ToString();
        }


    }
}
