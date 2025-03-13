using BidNexus.Models;
using BidNexus.Utils.ControllerBases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BidNexus.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsApiController : ApiBaseController
    {
        public ProductsApiController(BidNexusContext context):base(context)
        {
            
        }




    }
}
