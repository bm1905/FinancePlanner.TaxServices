using System.Data;

namespace FinancePlanner.TaxServices.Infrastructure.Persistence;

public interface IDapperContext
{
    IDbConnection CreateConnection();
}