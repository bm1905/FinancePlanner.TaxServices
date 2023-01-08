using System.Threading.Tasks;
using FinancePlanner.Shared.Models.TaxServices;
using FinancePlanner.TaxServices.Application.Features.TotalTaxes.Queries.GetTotalTaxesWithheld;

namespace FinancePlanner.TaxServices.Application.Services.TotalTaxesServices;

public interface ITotalTaxesServices
{
    Task<GetTotalTaxesWithheldQueryResponse> CalculateTotalTaxesWithheldAmount(CalculateTaxWithheldRequest request);
}