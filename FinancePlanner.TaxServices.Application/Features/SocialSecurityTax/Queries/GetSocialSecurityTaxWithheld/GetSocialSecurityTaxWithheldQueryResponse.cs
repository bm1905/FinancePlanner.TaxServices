namespace FinancePlanner.TaxServices.Application.Features.SocialSecurityTax.Queries.GetSocialSecurityTaxWithheld;

public class GetSocialSecurityTaxWithheldQueryResponse
{
    public decimal SocialSecurityTaxableWage { get; set; }
    public decimal SocialSecurityWithheldAmount { get; set; }
}