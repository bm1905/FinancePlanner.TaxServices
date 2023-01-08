using System;
using System.Threading.Tasks;
using FinancePlanner.TaxServices.Domain.Entities;

namespace FinancePlanner.TaxServices.Infrastructure.Repositories;

public interface ISocialSecurityTaxRepository
{
    Task<SocialSecurityTaxTable> GetSocialSecurityTaxPercentage(DateOnly date);
}