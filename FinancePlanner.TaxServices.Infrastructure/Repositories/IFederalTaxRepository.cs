using System.Threading.Tasks;
using FinancePlanner.TaxServices.Domain.Entities;

namespace FinancePlanner.TaxServices.Infrastructure.Repositories;

public interface IFederalTaxRepository
{
    Task<PercentageMethodTable> GetFederalTaxPercentage(decimal adjustedAnnualWage, string tableName);
}