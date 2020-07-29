using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper.Identity.Sample.Models.Identity
{
    public class ExtendedIdentityRole : IdentityRole<string>
    {
        public string Description { get; set; }
    }
}
