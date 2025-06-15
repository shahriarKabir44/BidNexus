using BidNexus.Jsons;
using BidNexus.Models;
using BidNexus.Repository;
using BidNexus.Utils;
using BidNexus.Utils.ControllerBases;
using BidNexus.Utils.JwtHandlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BidNexus.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    [JwtAuthorizeAttribute]
    public class ProductsApiController : SecureBaseController
    {   
        public ProductsApiController(BidNexusContext context) : base(context) { }

        [HttpGet("GetById")]
        public ApiResponse<ProductJson> GetById(int id = 0)
        {
            var data = new ApiResponse<ProductJson>();
            var error = "";
            try
            {
                using (var productRepo = new ProductRepository(DbInstance))
                {
                    var product = productRepo.GetById(id, out error);
                    if (product == null)
                    {
                        product = Product.GetNew();
                    }

                    var productJson = new ProductJson();
                    product.Map(productJson);
                    data.Data=productJson;
                }
            }
            catch (Exception e)
            {
                data.HasError = true;
                data.ErrorMsg = e.GetBaseException().Message;
            }
            return data;
        }

        [HttpGet("Hello")]

        public IActionResult Hello()
        {
            var x = Profile;
            return Ok("poop");
        }
    }
}
