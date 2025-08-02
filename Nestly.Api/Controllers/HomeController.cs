// |====================================================|
// |Copyright©                                          |
// |Nestly API - Home Finder                            |
// |Modern API to discover homes for rent  or purchase  |
// |                                                    | 
// |----------------------------------------------------|
// |                                                    | 
// |All rights reserved, including the right to         |
// |reproduce this work in any form. For permission     |
// |requests, contact [Your Contact Information]        |
// |====================================================|


using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace Nestly.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class HomeController : RESTFulController
    {
        [HttpGet]
        public ActionResult<string> Get() => Ok("Bye World");
    }
}
