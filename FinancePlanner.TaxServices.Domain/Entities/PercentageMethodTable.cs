namespace FinancePlanner.TaxServices.Domain.Entities;

public class PercentageMethodTable
{
    public decimal AtLeast { get; set; }
    public decimal ButLessThan { get; set; }
    public decimal TentativeHoldAmount { get; set; }
    public decimal Percentage { get; set; }
    public decimal Threshold { get; set; }
}