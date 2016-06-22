using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wamasys.Models.Database
{
    public class Gantry
    {
        public Gantry()
        {
            Items = new HashSet<Item>();
        }

        [Key]
        public int GantryId { get; set; }

        public string Name { get; set; }

        public int Limit { get; set; }

        public int XCoordinate { get; set; }

        public int YCoordinate { get; set; }

        public int ZCoordinate { get; set; }

        public int? BuildingId { get; set; }

        public virtual ICollection<Item> Items { get; set; }

        [ForeignKey("BuildingId")]
        public virtual Building Building { get; set; }
    }
}