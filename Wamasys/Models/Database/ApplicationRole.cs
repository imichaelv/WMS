using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Wamasys.Models.Database
{
    public class ApplicationRole : IdentityRole
    {
        public string Type { get; set; }
    }
}