using System.Threading;
using System.Threading.Tasks;
using FinancePlanner.TaxServices.Application.Services.SocialSecurityTaxServices;
using MediatR;

namespace FinancePlanner.TaxServices.Application.Features.SocialSecurityTax.Queries.GetSocialSecurityTaxWithheld;

public class GetSocialSecurityTaxWithheldQueryHandler : IRequestHandler<GetSocialSecurityTaxWithheldQuery, GetSocialSecurityTaxWithheldQueryResponse>
{
    private readonly ISocialSecurityTaxServices _socialSecurityTaxServices;

    public GetSocialSecurityTaxWithheldQueryHandler(ISocialSecurityTaxServices socialSecurityTaxServices)
    {
        _socialSecurityTaxServices = socialSecurityTaxServices;
    }

    public async Task<GetSocialSecurityTaxWithheldQueryResponse> Handle(GetSocialSecurityTaxWithheldQuery request, CancellationToken cancellationToken)
    {
        GetSocialSecurityTaxWithheldQueryResponse response = await _socialSecurityTaxServices.CalculateSocialSecurityTaxWithheldAmount(request.RequestModel);
        return response;
    }
}