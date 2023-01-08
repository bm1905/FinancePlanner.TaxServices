namespace FinancePlanner.TaxServices.Application.Features.StateTax.Queries.GetStateTaxWithheld;

public class GetStateTaxWithheldQueryResponse
{
    public decimal StateTaxableWage { get; set; }
    public decimal StateWithheldAmount { get; set; }
}