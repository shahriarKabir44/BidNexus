using BidNexus.Models;
using BidNexus.Utils.JwtHandlers;
using Microsoft.AspNetCore.Mvc;

namespace BidNexus.Utils.ControllerBases
{
    [JwtAuthorizeAttribute]
    public class SecureBaseController : BaseController
    {
        protected BidNexusContext DbInstance { get; set; }
        protected Profile Profile => HttpContext.Items["Profile"] as Profile;
        public SecureBaseController(BidNexusContext context) : base(context)
        {
            
            DbInstance=context;
        }
    }
}
