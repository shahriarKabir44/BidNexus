using BidNexus.Models;
using Microsoft.AspNetCore.Mvc;

namespace BidNexus.Utils.ControllerBases
{
    public class ApiBaseController : Controller
    {
        protected BidNexusContext DbInstance { get; set; }
        public ApiBaseController(BidNexusContext context)
        {
            DbInstance=context;
        }
    }
}
