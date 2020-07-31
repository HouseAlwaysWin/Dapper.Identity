using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Identity.Abstract
{
    public interface ITableInit
    {
        bool CreateRolesTable();

        bool CreateUsersTable();

        bool CreateUserRolesTable();

        bool CreateUserLoginsTable();

        bool CreateUserClaimsTable();

        bool CreateRoleClaimsTable();

        bool CreateUserTokensTable();
    }
}
