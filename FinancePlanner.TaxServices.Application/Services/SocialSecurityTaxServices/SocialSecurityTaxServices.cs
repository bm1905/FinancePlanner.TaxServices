using System;
using System.Threading.Tasks;
using FinancePlanner.Shared.Models.TaxServices;
using FinancePlanner.TaxServices.Application.Features.SocialSecurityTax.Queries.GetSocialSecurityTaxWithheld;
using FinancePlanner.TaxServices.Domain.Entities;
using FinancePlanner.TaxServices.Infrastructure.Repositories;

namespace FinancePlanner.TaxServices.Application.Services.SocialSecurityTaxServices;

public class SocialSecurityTaxServices : ISocialSecurityTaxServices
{
    private readonly ISocialSecurityTaxRepository _socialSecurityTaxRepository;

    public SocialSecurityTaxServices(ISocialSecurityTaxRepository socialSecurityTaxRepository)
    {
        _socialSecurityTaxRepository = socialSecurityTaxRepository;
    }

    public async Task<GetSocialSecurityTaxWithheldQueryResponse> CalculateSocialSecurityTaxWithheldAmount(CalculateTaxWithheldRequest request)
    {
        SocialSecurityTaxTable socialSecurityTaxPercentage = await _socialSecurityTaxRepository.GetSocialSecurityTaxPercentage(DateOnly.FromDateTime(DateTime.Now));
        decimal taxAmount;
        if (request.TaxableWageInformation.SocialAndMedicareTaxableWages <= socialSecurityTaxPercentage.WageBaseLimit)
        {
            taxAmount = socialSecurityTaxPercentage.TaxRate / 100 * request.TaxableWageInformation.SocialAndMedicareTaxableWages;
        }
        else
        {
            taxAmount = socialSecurityTaxPercentage.TaxRate / 100 * socialSecurityTaxPercentage.WageBaseLimit;
        }

        GetSocialSecurityTaxWithheldQueryResponse response = new()
        {
            SocialSecurityTaxableWage = request.TaxableWageInformation.SocialAndMedicareTaxableWages,
            SocialSecurityWithheldAmount = taxAmount
        };

        return response;
    }
}