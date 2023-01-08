using System;

namespace FinancePlanner.TaxServices.Domain.Entities;

public class MedicareTaxTable
{
    public DateOnly TaxYear { get; set; }
    public decimal TaxRate { get; set; }
    public decimal AdditionalTaxRate { get; set; }
    public decimal ThresholdWage { get; set; }
}