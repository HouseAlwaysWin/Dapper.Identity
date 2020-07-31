using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper.Identity.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class TableAttribute : Attribute
    {
        private string TableName { get; set; }
        private string Schema { get; set; }
        public TableAttribute(string tableName, string schema)
        {
            this.TableName = tableName;
            this.Schema = schema;
        }
    }
}
