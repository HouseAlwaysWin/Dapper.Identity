using Dapper.Identity.SqlQueries.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper.Identity.Adapters
{
    public class FbAdapter : ISqlAdapter
    {
        public IRolesQuery RolesQuery => throw new NotImplementedException();
    }
}
