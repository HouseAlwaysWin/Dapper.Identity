﻿using Dapper.Identity.Abstract;
using Dapper.Identity.SqlQueries;
using Dapper.Identity.SqlQueries.Abstract;
using Dapper.Identity.Tables;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper.Identity.Adapters
{
    public interface ISqlAdapter
    {
        IRolesQuery RolesQuery { get; }
    }
}
