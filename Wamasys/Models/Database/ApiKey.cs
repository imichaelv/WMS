using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wamasys.Models.Database
{
    public class ApiKey
    {
        [Key]
        public Guid ApiKeyId { get; set; }

        public string SecretKey { get; set; }

        public bool Disabled { get; set; }

        public string UserId { get; set; }

        public DateTime Created { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}