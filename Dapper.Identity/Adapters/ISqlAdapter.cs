using Dapper.Identity.Abstract;
using Dapper.Identity.Tables;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper.Identity.Adapters
{
    public interface ISqlAdapter
    {
        RolesTable<IdentityRole<string>, string, IdentityRoleClaim<string>> RolesTable(IDbConnectionFactory dbConnectionFactory);
    }
}
