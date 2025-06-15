using BidNexus.Models;
using Microsoft.AspNetCore.Mvc;

namespace BidNexus.Utils.ControllerBases
{
     public class BaseController : Controller
    {
        protected BidNexusContext DbInstance { get; set; }
         public BaseController(BidNexusContext context)
        {
            DbInstance=context;
        }
    }
}
