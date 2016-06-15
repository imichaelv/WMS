using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wamasys.Models
{
    /// <summary>
    /// Contains attributes for a company.
    /// </summary>
    public class CompanyViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string HouseNumber { get; set; }

        public string SiteOfficer { get; set; }

        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class CreateCompanyViewModel
    {
        
    }

    public class EditCompanyViewModel
    {
        
    }

    public class DeleteCompanyViewModel
    {
        
    }
}