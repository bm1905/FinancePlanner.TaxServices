using System;

namespace FinancePlanner.TaxServices.Domain.Entities;

public class SocialSecurityTaxTable
{
    public DateOnly TaxYear { get; set; }
    public decimal TaxRate { get; set; }
    public decimal WageBaseLimit { get; set; }
}