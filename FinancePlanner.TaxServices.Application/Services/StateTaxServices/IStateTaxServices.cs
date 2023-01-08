using System.Threading.Tasks;
using FinancePlanner.Shared.Models.TaxServices;
using FinancePlanner.TaxServices.Application.Features.StateTax.Queries.GetStateTaxWithheld;

namespace FinancePlanner.TaxServices.Application.Services.StateTaxServices;

public interface IStateTaxServices
{
    Task<GetStateTaxWithheldQueryResponse> CalculateStateTaxWithheldAmount(CalculateTaxWithheldRequest request);
}