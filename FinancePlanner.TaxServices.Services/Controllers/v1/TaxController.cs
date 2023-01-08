using System.Net;
using System.Threading.Tasks;
using FinancePlanner.Shared.Models.TaxServices;
using FinancePlanner.TaxServices.Application.Features.FederalTax.Queries.GetFederalTaxWithheld;
using FinancePlanner.TaxServices.Application.Features.MedicareTax.Queries.GetMedicareTaxWithheld;
using FinancePlanner.TaxServices.Application.Features.SocialSecurityTax.Queries.GetSocialSecurityTaxWithheld;
using FinancePlanner.TaxServices.Application.Features.StateTax.Queries.GetStateTaxWithheld;
using FinancePlanner.TaxServices.Application.Features.TotalTaxes.Queries.GetTotalTaxesWithheld;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinancePlanner.TaxServices.Services.Controllers.v1;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[Authorize("ApiScope")]
public class TaxController : ControllerBase
{
    private readonly IMediator _mediator;

    public TaxController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [AllowAnonymous]
    [MapToApiVersion("1.0")]
    [HttpGet("Test")]
    [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
    public IActionResult Index()
    {
        return Ok(new { Status = "V1 Test Passed" });
    }

    [MapToApiVersion("1.0")]
    [HttpPost("CalculateFederalTaxWithheld")]
    [ProducesResponseType(typeof(ActionResult<GetFederalTaxWithheldQueryResponse>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<GetFederalTaxWithheldQueryResponse>> CalculateFederalTaxWithheld([FromBody] CalculateTaxWithheldRequest request)
    {
        GetFederalTaxWithheldQuery query = new GetFederalTaxWithheldQuery(request);
        GetFederalTaxWithheldQueryResponse result = await _mediator.Send(query);
        return Ok(result);
    }

    [MapToApiVersion("1.0")]
    [HttpPost("CalculateMedicareTaxWithheld")]
    [ProducesResponseType(typeof(ActionResult<GetMedicareTaxWithheldQueryResponse>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<GetMedicareTaxWithheldQueryResponse>> CalculateMedicareTaxWithheld([FromBody] CalculateTaxWithheldRequest request)
    {
        GetMedicareTaxWithheldQuery query = new GetMedicareTaxWithheldQuery(request);
        GetMedicareTaxWithheldQueryResponse result = await _mediator.Send(query);
        return Ok(result);
    }

    [MapToApiVersion("1.0")]
    [HttpPost("CalculateSocialSecurityTaxWithheld")]
    [ProducesResponseType(typeof(ActionResult<GetSocialSecurityTaxWithheldQueryResponse>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<GetSocialSecurityTaxWithheldQueryResponse>> CalculateSocialSecurityTaxWithheld([FromBody] CalculateTaxWithheldRequest request)
    {
        GetSocialSecurityTaxWithheldQuery query = new GetSocialSecurityTaxWithheldQuery(request);
        GetSocialSecurityTaxWithheldQueryResponse result = await _mediator.Send(query);
        return Ok(result);
    }

    [MapToApiVersion("1.0")]
    [HttpPost("CalculateStateTaxWithheld")]
    [ProducesResponseType(typeof(ActionResult<GetStateTaxWithheldQueryResponse>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<GetStateTaxWithheldQueryResponse>> CalculateStateTaxWithheld([FromBody] CalculateTaxWithheldRequest request)
    {
        GetStateTaxWithheldQuery query = new GetStateTaxWithheldQuery(request);
        GetStateTaxWithheldQueryResponse result = await _mediator.Send(query);
        return Ok(result);
    }

    [MapToApiVersion("1.0")]
    [HttpPost("CalculateTotalTaxesWithheld")]
    [ProducesResponseType(typeof(ActionResult<GetTotalTaxesWithheldQueryResponse>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<GetTotalTaxesWithheldQueryResponse>> CalculateTotalTaxesWithheld([FromBody] CalculateTaxWithheldRequest request)
    {
        GetTotalTaxesWithheldQuery query = new GetTotalTaxesWithheldQuery(request);
        GetTotalTaxesWithheldQueryResponse result = await _mediator.Send(query);
        return Ok(result);
    }
}