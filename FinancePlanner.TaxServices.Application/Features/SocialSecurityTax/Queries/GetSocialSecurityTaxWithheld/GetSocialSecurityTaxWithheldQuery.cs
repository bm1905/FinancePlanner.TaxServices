using FinancePlanner.Shared.Models.TaxServices;
using MediatR;

namespace FinancePlanner.TaxServices.Application.Features.SocialSecurityTax.Queries.GetSocialSecurityTaxWithheld;

public class GetSocialSecurityTaxWithheldQuery : IRequest<GetSocialSecurityTaxWithheldQueryResponse>
{
    public GetSocialSecurityTaxWithheldQuery(CalculateTaxWithheldRequest requestModel)
    {
        RequestModel = requestModel;
    }

    public CalculateTaxWithheldRequest RequestModel { get; set; }
}