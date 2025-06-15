using Microsoft.AspNetCore.Mvc;
using System.Web;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BidNexus.Utils
{
    public class SecureControllerAttribute : Attribute, IAuthorizationFilter
    {
        public SecureControllerAttribute() { }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var profile = context.HttpContext.Items["Profile"] as Profile;
            if (profile == null)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
