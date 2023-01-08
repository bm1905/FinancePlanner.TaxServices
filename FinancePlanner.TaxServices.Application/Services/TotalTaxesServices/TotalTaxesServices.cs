using System;
using System.Threading.Tasks;
using FinancePlanner.Shared.Models.Common;
using FinancePlanner.Shared.Models.Enums;
using FinancePlanner.Shared.Models.Exceptions;
using FinancePlanner.Shared.Models.TaxServices;
using FinancePlanner.TaxServices.Application.Features.FederalTax.Queries.GetFederalTaxWithheld;
using FinancePlanner.TaxServices.Application.Features.MedicareTax.Queries.GetMedicareTaxWithheld;
using FinancePlanner.TaxServices.Application.Features.SocialSecurityTax.Queries.GetSocialSecurityTaxWithheld;
using FinancePlanner.TaxServices.Application.Features.StateTax.Queries.GetStateTaxWithheld;
using FinancePlanner.TaxServices.Application.Features.TotalTaxes.Queries.GetTotalTaxesWithheld;
using FinancePlanner.TaxServices.Application.Services.FederalTaxServices;
using FinancePlanner.TaxServices.Application.Services.FederalTaxServices.PluginHandler;
using FinancePlanner.TaxServices.Application.Services.MedicareTaxServices;
using FinancePlanner.TaxServices.Application.Services.SocialSecurityTaxServices;
using FinancePlanner.TaxServices.Application.Services.StateTaxServices;

namespace FinancePlanner.TaxServices.Application.Services.TotalTaxesServices;

public class TotalTaxesServices : ITotalTaxesServices
{
    private readonly FederalTaxPluginFactory _pluginFactory;
    private readonly IMedicareTaxServices _medicareTaxServices;
    private readonly ISocialSecurityTaxServices _socialSecurityTaxServices;
    private readonly IStateTaxServices _stateTaxServices;

    public TotalTaxesServices(IMedicareTaxServices medicareTaxServices, ISocialSecurityTaxServices socialSecurityTaxServices,
        FederalTaxPluginFactory pluginFactory, IStateTaxServices stateTaxServices
    )
    {
        _pluginFactory = pluginFactory;
        _medicareTaxServices = medicareTaxServices;
        _socialSecurityTaxServices = socialSecurityTaxServices;
        _stateTaxServices = stateTaxServices;
    }

    public async Task<GetTotalTaxesWithheldQueryResponse> CalculateTotalTaxesWithheldAmount(CalculateTaxWithheldRequest request)
    {
        W4Type w4Type = request.TaxInformation.W4Type;
        string? w4TypeName = Enum.GetName(typeof(W4Type), w4Type);
        if (w4TypeName == null)
        {
            throw new BadRequestException("Unable to get W4Type name");
        }

        IFederalTaxServices? service = _pluginFactory.GetService<IFederalTaxServices>(w4TypeName);
        if (service == null)
        {
            throw new ApplicationException("Something went wrong while loading plugin!");
        }

        GetFederalTaxWithheldQueryResponse federalTaxResponse =
            await service.CalculateFederalTaxWithheldAmount(request);
        GetMedicareTaxWithheldQueryResponse medicareTaxResponse =
            await _medicareTaxServices.CalculateMedicareTaxWithheldAmount(request);
        GetSocialSecurityTaxWithheldQueryResponse socialSecurityTaxResponse =
            await _socialSecurityTaxServices.CalculateSocialSecurityTaxWithheldAmount(request);
        GetStateTaxWithheldQueryResponse stateTaxResponse =
            await _stateTaxServices.CalculateStateTaxWithheldAmount(request);
        
        TaxWithheldInformationDto taxWithheldInformation = new ()
        {
            FederalTaxWithheldAmount = federalTaxResponse.FederalTaxWithheldAmount,
            MedicareWithheldAmount = medicareTaxResponse.MedicareWithheldAmount,
            SocialSecurityWithheldAmount = socialSecurityTaxResponse.SocialSecurityWithheldAmount,
            StateTaxWithheldAmount = stateTaxResponse.StateWithheldAmount,
            TotalTaxesWithheldAmount = federalTaxResponse.FederalTaxWithheldAmount + medicareTaxResponse.MedicareWithheldAmount
                + socialSecurityTaxResponse.SocialSecurityWithheldAmount + stateTaxResponse.StateWithheldAmount
        };

        TaxableWageInformationDto taxableWageInformation = new()
        {
            SocialAndMedicareTaxableWages = socialSecurityTaxResponse.SocialSecurityTaxableWage,
            StateAndFederalTaxableWages = federalTaxResponse.FederalTaxableWage
        };

        GetTotalTaxesWithheldQueryResponse response = new GetTotalTaxesWithheldQueryResponse()
        {
            TaxableWageInformation = taxableWageInformation,
            TaxWithheldInformation = taxWithheldInformation
        };

        return response;
    }
}