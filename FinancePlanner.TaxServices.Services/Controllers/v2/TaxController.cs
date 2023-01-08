using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace FinancePlanner.TaxServices.Services.Controllers.v2;

[ApiController]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class TaxController : ControllerBase
{
    [MapToApiVersion("2.0")]
    [HttpGet("Test")]
    [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
    public IActionResult Index()
    {
        return Ok(new { Status = "V2 Test Passed" });
    }
}