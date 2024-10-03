using Microsoft.AspNetCore.Mvc;
using Amplifund.Assignment.API.Core.Response;
using System.Net;

namespace Amplifund.Assignment.API.Core.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController<T> : ControllerBase
    {
        private readonly ILogger<T> _logger;

        public BaseController(ILogger<T> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Creates a result of an action method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response"></param>
        /// <returns>Object of ActionResult</returns>
        [NonAction]
        public async Task<IActionResult> CreateApiResponse<T>(T response)
        {
            return await Task.FromResult(new ApiActionResult<T>(response));
        }
    }
}
