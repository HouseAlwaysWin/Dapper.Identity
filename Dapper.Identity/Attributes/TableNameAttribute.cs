using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper.Identity.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class TableNameAttribute : Attribute
    {
        public string TableName { get; set; }
        public string Schema { get; set; }
        public TableNameAttribute(string tableName, string schema)
        {
            this.TableName = tableName;
            this.Schema = schema;
        }
    }
}
