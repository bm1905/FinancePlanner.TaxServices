using System.Reflection;
using System.Runtime.Loader;

namespace FinancePlanner.TaxServices.Application.Services.FederalTaxServices.PluginHandler;

public class FederalTaxPluginLoadContext : AssemblyLoadContext
{
    private readonly AssemblyDependencyResolver _resolver;
    public FederalTaxPluginLoadContext(string pluginPath)
    {
        _resolver = new AssemblyDependencyResolver(pluginPath);
    }

    protected override Assembly? Load(AssemblyName assemblyName)
    {
        string? assemblyPath = _resolver.ResolveAssemblyToPath(assemblyName);
        if (assemblyPath == null) return null;
        var assembly = LoadFromAssemblyPath(assemblyPath);
        return assembly;
    }
}