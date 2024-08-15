using Ibrahim.DoctorPortfolio.Errors;
using Microsoft.AspNetCore.Mvc;

namespace Ibrahim.DoctorPortfolio.Controllers
{
    [Route("errors/{statusCode}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ApiControllerBase
    {
        public IActionResult Handle(int statusCode)
        {
            return StatusCode(statusCode, ErrorResponse.Create(statusCode));
        }
    }
}
