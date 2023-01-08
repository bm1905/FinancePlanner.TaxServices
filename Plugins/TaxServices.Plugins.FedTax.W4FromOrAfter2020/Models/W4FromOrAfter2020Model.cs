using FinancePlanner.Shared.Models.Enums;

namespace TaxServices.Plugins.FedTax.W4FromOrAfter2020.Models;

public class W4FromOrAfter2020Model
{
    // This is Line 4a for 2022 W4 Form
    public decimal OtherIncome { get; set; }
    // This is Line 4b for 2022 W4 Form
    public decimal Deductions { get; set; }
    // This is Line 4c for 2022 W4 Form
    public decimal ExtraWithholding { get; set; }
    // This is step 2 for 2022 W4 Form
    public bool IsMultipleJobsChecked { get; set; }
    // This is step 3 for 2022 W4 Form
    public decimal ClaimDependentsAmount { get; set; }
    public string W4Type { get; set; } = string.Empty;
    public TaxFilingStatus TaxFilingStatus { get; set; }
    public decimal TaxableWage { get; set; }
    public int PayPeriodNumber { get; set; }
}