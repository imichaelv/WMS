using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Wamasys.Models.Database;

namespace Wamasys.Models
{
    public class ApiKeyViewModel
    {
        public List<ApiKey> ApiKeys { get; set; }
    }
}