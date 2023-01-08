using FinancePlanner.TaxServices.Application.Features.StateTax.Queries.GetStateTaxWithheld;
using FinancePlanner.TaxServices.Infrastructure.Repositories;
using System.Threading.Tasks;
using FinancePlanner.Shared.Models.TaxServices;

namespace FinancePlanner.TaxServices.Application.Services.StateTaxServices;

public class StateTaxServices : IStateTaxServices
{
    private readonly IStateTaxRepository _stateTaxRepository;

    public StateTaxServices(IStateTaxRepository stateTaxRepository)
    {
        _stateTaxRepository = stateTaxRepository;
    }

    public async Task<GetStateTaxWithheldQueryResponse> CalculateStateTaxWithheldAmount(CalculateTaxWithheldRequest request)
    {
        GetStateTaxWithheldQueryResponse response = new()
        {
            StateTaxableWage = request.TaxableWageInformation.StateAndFederalTaxableWages,
            StateWithheldAmount = 0
        };

        return await Task.FromResult(response);
    }
}