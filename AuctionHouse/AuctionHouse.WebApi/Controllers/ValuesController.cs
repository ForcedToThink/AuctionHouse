using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace AuctionHouse.WebApi.Controllers
{
    /// <summary>
    ///     Values controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        /// <summary>
        ///     Get values
        /// </summary>
        /// <remarks>Gets values.</remarks>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
