using System.Threading.Tasks;
using FinancePlanner.Shared.Models.TaxServices;
using FinancePlanner.TaxServices.Application.Features.SocialSecurityTax.Queries.GetSocialSecurityTaxWithheld;

namespace FinancePlanner.TaxServices.Application.Services.SocialSecurityTaxServices;

public interface ISocialSecurityTaxServices
{
    Task<GetSocialSecurityTaxWithheldQueryResponse> CalculateSocialSecurityTaxWithheldAmount(CalculateTaxWithheldRequest request);
}