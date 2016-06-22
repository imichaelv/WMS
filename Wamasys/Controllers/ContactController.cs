using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Wamasys.Models.Api;

namespace Wamasys.Controllers
{
    public class ContactController : ApiController
    {
        public Contact[] Get()
        {
            return new Contact[]
            {
        new Contact
        {
            Id = 1,
            Name = "Glenn Block"
        },
        new Contact
        {
            Id = 2,
            Name = "Dan Roth"
        }
            };
        }
    }
}