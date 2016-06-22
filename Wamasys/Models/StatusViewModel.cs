using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wamasys.Models
{
    /// <summary>
    /// Contains atributes for statuses.
    /// </summary>
    public class StatusViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}