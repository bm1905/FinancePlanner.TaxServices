namespace FinancePlanner.TaxServices.Application.Services.FederalTaxServices.PluginHandler;

public interface IFederalTaxPluginFactory
{
    T? GetService<T>(string w4Type);
    void Initialize();
}