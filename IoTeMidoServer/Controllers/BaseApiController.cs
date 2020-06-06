using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IoTeMidoServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : Controller
    {
        protected IActionResult HandleException(Exception ex, string msg)
        {
            IActionResult result;

            // Create new exception with generic message        
            result = StatusCode(StatusCodes.Status500InternalServerError, new Exception(msg, ex));

            return result;
        }
    }
}