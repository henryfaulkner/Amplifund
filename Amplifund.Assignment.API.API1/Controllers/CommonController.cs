using Amplifund.Assignment.API.Core.Controller;
using Amplifund.Assignment.API.Core.Response;
using Amplifund.Assignment.BL.Common.Interactor;
using Amplifund.Assignment.Domain.Entities.Common;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Amplifund.Assignment.API.API1.Controllers
{
    public class CommonController : BaseController<CommonController>
    {
        private readonly ILogger<CommonController> _logger;
        private readonly ICommonInteractor _commonInteractor;

        public CommonController(ILogger<CommonController> logger, ICommonInteractor commonInteractor) : base(logger)
        {
            _logger = logger;
            _commonInteractor = commonInteractor;
        }

        [HttpGet]
        [Route("states")]
        [SwaggerResponse(StatusCodes.Status200OK, "The request succeeded.", typeof(ApiResponse<List<State>>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "A server error occurred.")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "The request is malformed.")]
        [SwaggerOperation(
            Summary = "Get all U.S. States.",
            Description = "Returns all 50 U.S. States."
        )]
        public async Task<IActionResult> GetStates()
        {
            _logger.LogInformation("Start GetStates");
            var response = await _commonInteractor.GetStates();
            _logger.LogInformation("End GetStates");
            return await CreateApiResponse(response);
        }
    }
}
