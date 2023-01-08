using System.Threading.Tasks;
using FinancePlanner.Shared.Models.TaxServices;
using FinancePlanner.TaxServices.Application.Features.FederalTax.Queries.GetFederalTaxWithheld;

namespace FinancePlanner.TaxServices.Application.Services.FederalTaxServices;

public interface IFederalTaxServices
{
    Task<GetFederalTaxWithheldQueryResponse> CalculateFederalTaxWithheldAmount(CalculateTaxWithheldRequest request);
}