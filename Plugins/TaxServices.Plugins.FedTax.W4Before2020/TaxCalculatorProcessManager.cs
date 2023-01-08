using System.Threading.Tasks;
using FinancePlanner.Shared.Models.TaxServices;
using FinancePlanner.TaxServices.Application.Features.FederalTax.Queries.GetFederalTaxWithheld;
using FinancePlanner.TaxServices.Application.Services.FederalTaxServices;
using FinancePlanner.TaxServices.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using TaxServices.Plugins.FedTax.W4Before2020.Models;

namespace TaxServices.Plugins.FedTax.W4Before2020;

public class TaxCalculatorProcessManager : IFederalTaxServices
{
    private readonly TaxCalculatorManager _taxCalculatorManager;
    private readonly IConfiguration _configuration;

    public TaxCalculatorProcessManager(IConfiguration configuration, IFederalTaxRepository federalTaxBracketRepository)
    {
        _configuration = configuration;
        _taxCalculatorManager = new TaxCalculatorManager(federalTaxBracketRepository);
    }

    public async Task<GetFederalTaxWithheldQueryResponse> CalculateFederalTaxWithheldAmount(CalculateTaxWithheldRequest model)
    {
        W4Before2020Model w4Before2020Model = _taxCalculatorManager.GetModel(model);
        decimal adjustedAnnualWage = _taxCalculatorManager.GetAdjustedAnnualWage(w4Before2020Model, _configuration);
        decimal federalTaxWithheldAmount = await _taxCalculatorManager.GetFederalTaxWithheldAmount(w4Before2020Model, adjustedAnnualWage);

        GetFederalTaxWithheldQueryResponse response = new GetFederalTaxWithheldQueryResponse
        {
            FederalTaxableWage = model.TaxableWageInformation.StateAndFederalTaxableWages,
            FederalTaxWithheldAmount = federalTaxWithheldAmount
        };

        return response;
    }
}