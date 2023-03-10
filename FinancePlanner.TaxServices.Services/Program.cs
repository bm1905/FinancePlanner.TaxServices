using FinancePlanner.TaxServices.Application.Extensions;
using FinancePlanner.TaxServices.Infrastructure.Extensions;
using FinancePlanner.TaxServices.Services.Extensions;
using FinancePlanner.TaxServices.Services.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using System;
using FinancePlanner.TaxServices.Services.Initializer;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;
//IWebHostEnvironment environment = builder.Environment;

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();
builder.Services.AddApplicationServices().AddInfrastructureServices().AddWebApiServices(configuration);

// Build the app
WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        IApiVersionDescriptionProvider provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
        }
    });
}

app.UseMiddleware<PerformanceMiddleware>();

app.UseMiddleware<ExceptionMiddleware>();

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHealthChecks("/healthcheck", new HealthCheckOptions()
    {
        Predicate = _ => true,
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });
});

app.Logger.LogInformation("Seeding database...");
bool isSeedingSuccessful = await DbInitializer.EnsureSeedData(app);
if (isSeedingSuccessful)
{
    app.Logger.LogInformation("Done Seeding database. Exiting.");
}
else
{
    app.Logger.LogError("Seeding database failed. Exiting.");
    throw new Exception("Seeding database failed.");
}

app.Run();
