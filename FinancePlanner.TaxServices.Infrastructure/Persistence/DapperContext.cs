using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace FinancePlanner.TaxServices.Infrastructure.Persistence;

public class DapperContext : IDapperContext
{
    private readonly string? _connectionString;

    public DapperContext(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DatabaseConnection");
    }

    public IDbConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }
}