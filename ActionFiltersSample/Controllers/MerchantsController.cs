using ActionFiltersSample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ActionFiltersSample.Controllers
{
    [Route("api/{merchantCore}/[controller]")]
    [ApiController]
    public class MerchantsController : ControllerBase
    {
        [HttpGet]
        [Route("GetCars")]

        public IActionResult GetCars ([FromQuery] string merchantCode)
        {
            return Ok($"YourMerchantCore {merchantCode}");
        }
        [HttpPost]

        public IActionResult UpdateMerchant(MerchantUpdateRequestModel merchantCode)
        {
            return Ok($"MerchantCodeUpdate Code :  {merchantCode.MerchantCode} , Name :{merchantCode.Name}  ");

        }
    }
}
