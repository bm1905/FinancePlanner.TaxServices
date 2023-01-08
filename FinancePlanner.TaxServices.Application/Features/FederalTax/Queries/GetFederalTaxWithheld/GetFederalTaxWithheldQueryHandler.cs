using System;
using System.Threading;
using System.Threading.Tasks;
using FinancePlanner.Shared.Models.Enums;
using FinancePlanner.Shared.Models.Exceptions;
using FinancePlanner.TaxServices.Application.Services.FederalTaxServices;
using FinancePlanner.TaxServices.Application.Services.FederalTaxServices.PluginHandler;
using MediatR;

namespace FinancePlanner.TaxServices.Application.Features.FederalTax.Queries.GetFederalTaxWithheld;

public class GetFederalTaxWithheldQueryHandler : IRequestHandler<GetFederalTaxWithheldQuery, GetFederalTaxWithheldQueryResponse>
{
    private readonly FederalTaxPluginFactory _pluginFactory;

    public GetFederalTaxWithheldQueryHandler(FederalTaxPluginFactory pluginFactory)
    {
        _pluginFactory = pluginFactory;
    }

    public async Task<GetFederalTaxWithheldQueryResponse> Handle(GetFederalTaxWithheldQuery request, CancellationToken cancellationToken)
    {
        W4Type w4Type = request.RequestModel.TaxInformation.W4Type;
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

        GetFederalTaxWithheldQueryResponse response = await service.CalculateFederalTaxWithheldAmount(request.RequestModel);
        return response;
    }
}