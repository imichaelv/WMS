using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wamasys.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Minimum amount")]
        public int MinimumAmount { get; set; }

        public int PropertyId { get; set; }
    }
}