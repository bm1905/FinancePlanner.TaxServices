using System.Reflection;
using FinancePlanner.TaxServices.Application.Behaviours;
using FinancePlanner.TaxServices.Application.Services.FederalTaxServices.PluginHandler;
using FinancePlanner.TaxServices.Application.Services.MedicareTaxServices;
using FinancePlanner.TaxServices.Application.Services.SocialSecurityTaxServices;
using FinancePlanner.TaxServices.Application.Services.StateTaxServices;
using FinancePlanner.TaxServices.Application.Services.TotalTaxesServices;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using FinancePlanner.TaxServices.Infrastructure.Repositories;

namespace FinancePlanner.TaxServices.Application.Extensions;

public static class ApplicationServiceExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(typeof(FederalTaxPluginFactory).Assembly);
        services.AddScoped(serviceProvider =>
        {
            IConfiguration configuration = serviceProvider.GetRequiredService<IConfiguration>();
            IFederalTaxRepository federalTaxRepository = serviceProvider.GetRequiredService<IFederalTaxRepository>();
            FederalTaxPluginFactory pluginFactory = new FederalTaxPluginFactory(configuration, federalTaxRepository);
            pluginFactory.Initialize();
            return pluginFactory;
        });
        services.AddScoped<IStateTaxServices, StateTaxServices>();
        services.AddScoped<IMedicareTaxServices, MedicareTaxServices>();
        services.AddScoped<ISocialSecurityTaxServices, SocialSecurityTaxServices>();
        services.AddScoped<IStateTaxServices, StateTaxServices>();
        services.AddScoped<ITotalTaxesServices, TotalTaxesServices>();
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        return services;
    }
}