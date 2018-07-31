using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuctionHouse.WebApi.Controllers
{
    /// <summary>
    ///     The base controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BaseController : ControllerBase
    {
        
    }
}