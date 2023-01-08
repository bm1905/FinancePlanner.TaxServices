using System.Threading;
using System.Threading.Tasks;
using FinancePlanner.TaxServices.Application.Services.MedicareTaxServices;
using MediatR;

namespace FinancePlanner.TaxServices.Application.Features.MedicareTax.Queries.GetMedicareTaxWithheld;

public class GetMedicareTaxWithheldQueryHandler : IRequestHandler<GetMedicareTaxWithheldQuery, GetMedicareTaxWithheldQueryResponse>
{
    private readonly IMedicareTaxServices _medicareTaxServices;

    public GetMedicareTaxWithheldQueryHandler(IMedicareTaxServices medicareTaxServices)
    {
        _medicareTaxServices = medicareTaxServices;
    }

    public async Task<GetMedicareTaxWithheldQueryResponse> Handle(GetMedicareTaxWithheldQuery request, CancellationToken cancellationToken)
    {
        GetMedicareTaxWithheldQueryResponse response = await _medicareTaxServices.CalculateMedicareTaxWithheldAmount(request.RequestModel);
        return response;
    }
}