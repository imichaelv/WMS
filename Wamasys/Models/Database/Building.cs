using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Wamasys.Models.Database
{
    public class Building
    {
        public Building()
        {
            Gantries = new HashSet<Gantry>();
        }

        [Key]
        public int BuildingId { get; set; }

        public string Name { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public int HouseNumber { get; set; }

        public int XCoordinate { get; set; }

        public int YCoordinate { get; set; }

        public int ZCoordinate { get; set; }


        public virtual ICollection<Gantry> Gantries { get; set; }
    }
}