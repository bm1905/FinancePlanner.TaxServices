using FinancePlanner.Shared.Models.TaxServices;
using MediatR;

namespace FinancePlanner.TaxServices.Application.Features.StateTax.Queries.GetStateTaxWithheld;

public class GetStateTaxWithheldQuery : IRequest<GetStateTaxWithheldQueryResponse>
{
    public GetStateTaxWithheldQuery(CalculateTaxWithheldRequest requestModel)
    {
        RequestModel = requestModel;
    }

    public CalculateTaxWithheldRequest RequestModel { get; set; }
}