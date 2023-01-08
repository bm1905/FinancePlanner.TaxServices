namespace FinancePlanner.TaxServices.Application.Features.MedicareTax.Queries.GetMedicareTaxWithheld;

public class GetMedicareTaxWithheldQueryResponse
{
    public decimal MedicareTaxableWage { get; set; }
    public decimal MedicareWithheldAmount { get; set; }
}