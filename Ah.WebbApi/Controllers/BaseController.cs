using CommonTypesLayer.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ah.WebbApi.Controllers
{
    //bu bir EndPoint değil
    public class BaseController : ControllerBase
    {
        [NonAction]
        public IActionResult SendResponse<T>(ApiResponse<T> response)
        {
            if (response.StatusCode == StatusCodes.Status204NoContent)
                return new ObjectResult(null) { StatusCode = response.StatusCode };
            
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
    }
}
