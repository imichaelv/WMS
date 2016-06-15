using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wamasys.Models
{
    public class ItemViewModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int CustomerId { get; set; }

        public int GantryId { get; set; }
    }
}