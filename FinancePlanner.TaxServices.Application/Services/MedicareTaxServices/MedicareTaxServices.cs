using System;
using FinancePlanner.TaxServices.Application.Features.MedicareTax.Queries.GetMedicareTaxWithheld;
using System.Threading.Tasks;
using FinancePlanner.Shared.Models.TaxServices;
using FinancePlanner.TaxServices.Domain.Entities;
using FinancePlanner.TaxServices.Infrastructure.Repositories;

namespace FinancePlanner.TaxServices.Application.Services.MedicareTaxServices;

public class MedicareTaxServices : IMedicareTaxServices
{
    private readonly IMedicareTaxRepository _medicareTaxRepository;

    public MedicareTaxServices(IMedicareTaxRepository medicareTaxRepository)
    {
        _medicareTaxRepository = medicareTaxRepository;
    }

    public async Task<GetMedicareTaxWithheldQueryResponse> CalculateMedicareTaxWithheldAmount(CalculateTaxWithheldRequest request)
    {
        MedicareTaxTable medicareTaxPercentage = await _medicareTaxRepository.GetMedicareTaxPercentage(DateOnly.FromDateTime(DateTime.Now));
        decimal taxAmount = medicareTaxPercentage.TaxRate / 100 * request.TaxableWageInformation.SocialAndMedicareTaxableWages;
        if (request.TaxableWageInformation.SocialAndMedicareTaxableWages > medicareTaxPercentage.ThresholdWage)
        {
            taxAmount += (medicareTaxPercentage.AdditionalTaxRate / 100) * (request.TaxableWageInformation.SocialAndMedicareTaxableWages - medicareTaxPercentage.ThresholdWage);
        }

        GetMedicareTaxWithheldQueryResponse response = new()
        {
            MedicareTaxableWage = request.TaxableWageInformation.SocialAndMedicareTaxableWages,
            MedicareWithheldAmount = taxAmount
        };

        return response;
    }
}