using System.Threading;
using System.Threading.Tasks;
using FinancePlanner.TaxServices.Application.Services.TotalTaxesServices;
using MediatR;

namespace FinancePlanner.TaxServices.Application.Features.TotalTaxes.Queries.GetTotalTaxesWithheld;

public class GetTotalTaxesWithheldQueryHandler : IRequestHandler<GetTotalTaxesWithheldQuery, GetTotalTaxesWithheldQueryResponse>
{
    private readonly ITotalTaxesServices _totalTaxesServices;

    public GetTotalTaxesWithheldQueryHandler(ITotalTaxesServices totalTaxesServices)
    {
        _totalTaxesServices = totalTaxesServices;
    }

    public async Task<GetTotalTaxesWithheldQueryResponse> Handle(GetTotalTaxesWithheldQuery request, CancellationToken cancellationToken)
    {
        GetTotalTaxesWithheldQueryResponse response =
            await _totalTaxesServices.CalculateTotalTaxesWithheldAmount(request.RequestModel);
        return response;
    }
}