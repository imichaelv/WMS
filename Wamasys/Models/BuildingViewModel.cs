using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wamasys.Models
{
    /// <summary>
    /// Contains attributes for a building.
    /// </summary>
    public class BuildingViewModel
    {   
        public string Name { get; set; }
        
        public string Street { get; set; }
        
        public string City { get; set; }
        
        public string HouseNumber { get; set; }
        
        /// <summary>
        /// The amount of rows (width) that a building has.
        /// </summary>
        public int XCoordinate { get; set; } 

        /// <summary>
        /// The amount of columns (depth) that a building has.
        /// </summary>
        public int YCoordinate { get; set; }

        /// <summary>
        /// The amount of stories a building has.
        /// </summary>
        public int ZCoordinate { get; set; }
    }

    public class CreateBuildingViewModel
    {
        
    }

    public class EditBuildingViewModel
    {
        
    }

    public class DeleteBuildingViewModel
    {
        
    }
}