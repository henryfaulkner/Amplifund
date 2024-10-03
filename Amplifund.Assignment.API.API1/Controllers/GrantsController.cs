using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Amplifund.Assignment.API.Core.Response;
using Amplifund.Assignment.API.Core.Controller;
using Amplifund.Assignment.BL.Grants.Interactor;
using Amplifund.Assignment.Domain.Entities.Grant;
using Amplifund.Assignment.Model;
using Amplifund.Assignment.Domain.Entities.Common;

namespace Amplifund.Assignment.API.API1.Controllers
{
    public class GrantsController : BaseController<GrantsController>
    {
        private readonly ILogger<GrantsController> _logger;
        private readonly IGrantsInteractor _grantsInteractor;

        public GrantsController(ILogger<GrantsController> logger, IGrantsInteractor grantsInteractor) : base(logger)
        {
            _logger = logger;
            _grantsInteractor = grantsInteractor;
        }

        [HttpPost]
        [Route("grant")]
        [SwaggerResponse(StatusCodes.Status200OK, "The request succeeded.", typeof(ApiResponse<Grant>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "A server error occurred.")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "The request is malformed.")]
        [SwaggerOperation(
            Summary = "Create a new grant.",
            Description = "This endpoint creates a new grant record in the database."
        )]
        public async Task<IActionResult> CreateGrant(Grant_POST grant)
        {
            _logger.LogInformation("Start CreateGrant");
            var response = await _grantsInteractor.CreateGrant(grant.RefNumber, grant.Name, grant.Amount);
            _logger.LogInformation("End CreateGrant");
            return await CreateApiResponse(response);
        }

        [HttpPost]
        [Route("state-grant")]
        [SwaggerResponse(StatusCodes.Status200OK, "The request succeeded.", typeof(ApiResponse<StateGrant>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "A server error occurred.")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "The request is malformed.")]
        [SwaggerOperation(
            Summary = "Create a new state grant.",
            Description = "This endpoint creates a new state grant record in the database."
        )]
        public async Task<IActionResult> CreateStateGrant(StateGrant_POST stateGrant)
        {
            _logger.LogInformation("Start CreateStateGrant");
            var response = await _grantsInteractor.CreateStateGrant(stateGrant.RefNumber, stateGrant.Name, stateGrant.Amount, stateGrant.StateId);
            _logger.LogInformation("End CreateStateGrant");
            return await CreateApiResponse(response);
        }

        [HttpPut]
        [Route("update-grant")]
        [SwaggerResponse(StatusCodes.Status200OK, "The request succeeded.", typeof(ApiResponse<StateGrant>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "A server error occurred.")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "The request is malformed.")]
        [SwaggerOperation(
            Summary = "Update the grant amount.",
            Description = "This endpoint updates the amount of an existing state grant record in the database."
        )]
        public async Task<IActionResult> UpdateGrantAmount([FromBody] Grant_UPDATE grant)
        {
            _logger.LogInformation("Start UpdateGrantAmount");
            var response = await _grantsInteractor.UpdateGrantAmount(grant.Id, grant.NewAmount);
            _logger.LogInformation("End UpdateGrantAmount");
            return await CreateApiResponse(response);
        }

        [HttpGet]
        [Route("grants")]
        [SwaggerResponse(StatusCodes.Status200OK, "The request succeeded.", typeof(ApiResponse<List<Grant>>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "A server error occurred.")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "The request is malformed.")]
        [SwaggerOperation(
            Summary = "Get all grants ever created.",
            Description = "This endpoint returns every grant in the app database. Lol probably not great at scale."
        )]
        public async Task<IActionResult> GetGrants()
        {
            _logger.LogInformation("Start GetGrants");
            var response = await _grantsInteractor.GetGrants();
            _logger.LogInformation("End GetGrants");
            return await CreateApiResponse(response);
        }

        [HttpGet]
        [Route("state-grants")]
        [SwaggerResponse(StatusCodes.Status200OK, "The request succeeded.", typeof(ApiResponse<List<StateGrant>>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "A server error occurred.")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "The request is malformed.")]
        [SwaggerOperation(
            Summary = "Get all state grants ever created.",
            Description = "This endpoint returns every state grant in the app database."
        )]
        public async Task<IActionResult> GetStateGrants()
        {
            _logger.LogInformation("Start GetStateGrants");
            var response = await _grantsInteractor.GetStateGrants();
            _logger.LogInformation("End GetStateGrants");
            return await CreateApiResponse(response);
        }

        [HttpGet]
        [Route("state-grants/{stateId}")]
        [SwaggerResponse(StatusCodes.Status200OK, "The request succeeded.", typeof(ApiResponse<List<StateGrant>>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "A server error occurred.")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "The request is malformed.")]
        [SwaggerOperation(
            Summary = "Get all state grants for a particular state.",
            Description = "This endpoint returns every state grant for a particular state in the app database."
        )]
        public async Task<IActionResult> GetStateGrantsByState(int stateId)
        {
            _logger.LogInformation("Start GetStateGrantsByState");
            var response = await _grantsInteractor.GetStateGrantsByState(stateId);
            _logger.LogInformation("End GetStateGrantsByState");
            return await CreateApiResponse(response);
        }

        [HttpDelete]
        [Route("delete-grant/{grantId}")]
        [SwaggerResponse(StatusCodes.Status200OK, "The grant was deleted successfully.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "A server error occurred.")]
        [SwaggerOperation(
            Summary = "Delete a grant.",
            Description = "This endpoint deletes a grant record from the database."
        )]
        public async Task<IActionResult> DeleteGrant(long grantId)
        {
            _logger.LogInformation("Start DeleteGrant");
            var response = await _grantsInteractor.DeleteGrant(grantId);
            _logger.LogInformation("End DeleteGrant");
            return await CreateApiResponse(response);
        }

        [HttpDelete]
        [Route("state-grant/{stateGrantId}")]
        [SwaggerResponse(StatusCodes.Status200OK, "The state grant was deleted successfully.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "A server error occurred.")]
        [SwaggerOperation(
            Summary = "Delete a state grant.",
            Description = "This endpoint deletes a state grant record from the database."
        )]
        public async Task<IActionResult> DeleteStateGrant(long stateGrantId)
        {
            _logger.LogInformation("Start DeleteStateGrant");
            var response = await _grantsInteractor.DeleteStateGrant(stateGrantId);
            _logger.LogInformation("End DeleteStateGrant");
            return await CreateApiResponse(response);
        }
    }
}
