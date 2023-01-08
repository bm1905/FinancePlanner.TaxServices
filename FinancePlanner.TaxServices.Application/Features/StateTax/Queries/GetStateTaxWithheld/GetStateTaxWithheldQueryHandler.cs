using System.Threading;
using System.Threading.Tasks;
using FinancePlanner.TaxServices.Application.Services.StateTaxServices;
using MediatR;

namespace FinancePlanner.TaxServices.Application.Features.StateTax.Queries.GetStateTaxWithheld;

public class GetStateTaxWithheldQueryHandler : IRequestHandler<GetStateTaxWithheldQuery, GetStateTaxWithheldQueryResponse>
{
    private readonly IStateTaxServices _stateTaxServices;

    public GetStateTaxWithheldQueryHandler(IStateTaxServices stateTaxServices)
    {
        _stateTaxServices = stateTaxServices;
    }

    public async Task<GetStateTaxWithheldQueryResponse> Handle(GetStateTaxWithheldQuery request, CancellationToken cancellationToken)
    {
        GetStateTaxWithheldQueryResponse response = await _stateTaxServices.CalculateStateTaxWithheldAmount(request.RequestModel);
        return response;
    }
}