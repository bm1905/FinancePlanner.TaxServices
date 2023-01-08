using FinancePlanner.TaxServices.Infrastructure.Persistence;
using FinancePlanner.TaxServices.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FinancePlanner.TaxServices.Infrastructure.Extensions;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IDapperContext, DapperContext>();
        services.AddScoped<IMedicareTaxRepository, MedicareTaxRepository>();
        services.AddScoped<ISocialSecurityTaxRepository, SocialSecurityTaxRepository>();
        services.AddScoped<IFederalTaxRepository, FederalTaxRepository>();
        services.AddScoped<IStateTaxRepository, StateTaxRepository>();
        return services;
    }
}