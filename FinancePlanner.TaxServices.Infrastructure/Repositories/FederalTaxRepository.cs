using System.Data;
using FinancePlanner.TaxServices.Domain.Entities;
using System.Threading.Tasks;
using Dapper;
using FinancePlanner.TaxServices.Infrastructure.Persistence;

namespace FinancePlanner.TaxServices.Infrastructure.Repositories;

public class FederalTaxRepository : IFederalTaxRepository
{
    private readonly IDapperContext _context;

    public FederalTaxRepository(IDapperContext context)
    {
        _context = context;
    }

    public async Task<PercentageMethodTable> GetFederalTaxPercentage(decimal adjustedAnnualWage, string tableName)
    {
        string query = "SELECT " +
                       "At_Least AS AtLeast, " +
                       "But_Less_Than AS ButLessThan, " +
                       "Tentative_Hold_Amount AS TentativeHoldAmount, " +
                       "Percentage AS Percentage, " +
                       "Threshold AS Threshold " +
                       $"FROM {tableName} " +
                       $"WHERE {adjustedAnnualWage} >= At_Least " +
                       $"AND {adjustedAnnualWage} < But_Less_Than;";
        using IDbConnection connection = _context.CreateConnection();
        PercentageMethodTable percentageMethodTable = await connection
            .QuerySingleAsync<PercentageMethodTable>(query);
        return percentageMethodTable;
    }
}