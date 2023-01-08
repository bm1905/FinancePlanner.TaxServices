using System.Threading.Tasks;
using FinancePlanner.Shared.Models.TaxServices;
using FinancePlanner.TaxServices.Application.Features.MedicareTax.Queries.GetMedicareTaxWithheld;

namespace FinancePlanner.TaxServices.Application.Services.MedicareTaxServices;

public interface IMedicareTaxServices
{
    Task<GetMedicareTaxWithheldQueryResponse> CalculateMedicareTaxWithheldAmount(CalculateTaxWithheldRequest request);
}