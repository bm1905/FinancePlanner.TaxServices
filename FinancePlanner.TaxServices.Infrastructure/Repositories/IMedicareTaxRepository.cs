using System;
using System.Threading.Tasks;
using FinancePlanner.TaxServices.Domain.Entities;

namespace FinancePlanner.TaxServices.Infrastructure.Repositories;

public interface IMedicareTaxRepository
{
    Task<MedicareTaxTable> GetMedicareTaxPercentage(DateOnly date);
}