namespace FinancePlanner.TaxServices.Application.Features.FederalTax.Queries.GetFederalTaxWithheld;

public class GetFederalTaxWithheldQueryResponse
{
    public decimal FederalTaxableWage { get; set; }
    public decimal FederalTaxWithheldAmount { get; set; }
}