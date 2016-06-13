using System.Web.Mvc;

namespace Wamasys.Identity
{
    public class AuthorizeRoles : AuthorizeAttribute
    {
        public AuthorizeRoles(params string[] roles)
        {
            Roles = string.Join(",", roles);
        }
    }
}