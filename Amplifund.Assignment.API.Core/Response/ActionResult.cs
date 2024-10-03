using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Amplifund.Assignment.API.Core.Response
{
    public class ApiActionResult : IActionResult
    {
        public virtual async Task ExecuteResultAsync(ActionContext context)
        {
            await ExecuteResultAsync(context);
        }
    }

    public class ApiActionResult<T> : ApiActionResult
    {
        public ApiResponse<T> Data;

        public ApiActionResult(T data)
        {
            Data = new ApiResponse<T>("Request successful.", data, StatusCodes.Status200OK);
        }

        public override async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(Data)
            {
                StatusCode = Data.StatusCode
            };
            await objectResult.ExecuteResultAsync(context);
        }
    }
}