using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using FinancePlanner.Shared.Models.Exceptions;
using FinancePlanner.TaxServices.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;

namespace FinancePlanner.TaxServices.Application.Services.FederalTaxServices.PluginHandler;

public class FederalTaxPluginFactory : IFederalTaxPluginFactory
{
    private readonly Dictionary<string, Assembly?> _pluginMap;
    private readonly Dictionary<string, string?> _pluginConfig;
    private readonly IConfiguration _configuration;
    private readonly IFederalTaxRepository _federalTaxBracketRepository;

    public FederalTaxPluginFactory(IConfiguration configuration, IFederalTaxRepository federalTaxBracketRepository)
    {
        _pluginMap = new Dictionary<string, Assembly?>();
        _configuration = configuration;
        _federalTaxBracketRepository = federalTaxBracketRepository;
        _pluginConfig = _configuration.GetSection("W4PluginConfig")
            .GetChildren()
            .ToDictionary(x => x.Key, x => x.Value);
    }

    public static Assembly LoadPlugin(string? assemblyFileName)
    {
        string solutionRoot = Path.GetFullPath(Path.GetDirectoryName(typeof(FederalTaxPluginFactory).Assembly.Location)
                                               ?? throw new ApplicationException("Something went wrong while getting assembly path!"));
        string pluginLocation = Path.GetFullPath(Path.Combine(solutionRoot, $"plugins\\{Path.GetFileNameWithoutExtension(assemblyFileName)}",
            assemblyFileName?.Replace('\\', Path.DirectorySeparatorChar) ?? string.Empty));
        FederalTaxPluginLoadContext loadContext = new FederalTaxPluginLoadContext(pluginLocation);
        return loadContext.LoadFromAssemblyName(new AssemblyName(Path.GetFileNameWithoutExtension(pluginLocation)));
    }

    public T? GetService<T>(string w4Type)
    {
        try
        {
            _pluginMap.TryGetValue(w4Type, out Assembly? assembly);
            Type? pluginType = assembly?.GetTypes().FirstOrDefault(c => typeof(T).IsAssignableFrom(c));

            if (pluginType == null)
                throw new InternalServerErrorException($"No plugin implementing the interface {nameof(T)} and with name " +
                                                       $"{w4Type} found in {assembly} at {assembly?.Location}");

            T? pluginService = (T)Activator.CreateInstance(pluginType, _configuration, _federalTaxBracketRepository)!;
            if (pluginService == null) throw new InternalServerErrorException("Unable to load plugin service");
            return pluginService;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return default;
        }
    }

    public void Initialize()
    {
        foreach (KeyValuePair<string, string?> plugin in _pluginConfig)
        {
            (string pluginKey, string? pluginFile) = plugin;
            Assembly assembly = LoadPlugin(pluginFile);
            _pluginMap[pluginKey] = assembly;
        }
    }
}