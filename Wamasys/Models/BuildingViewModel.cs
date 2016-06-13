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
        
        public int XCoordinate { get; set; } 

        public int YCoordinate { get; set; }

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