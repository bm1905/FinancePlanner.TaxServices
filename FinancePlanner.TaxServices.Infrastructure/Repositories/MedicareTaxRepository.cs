using System;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using FinancePlanner.TaxServices.Domain.Entities;
using FinancePlanner.TaxServices.Infrastructure.Persistence;

namespace FinancePlanner.TaxServices.Infrastructure.Repositories;

public class MedicareTaxRepository : IMedicareTaxRepository
{
    private readonly IDapperContext _context;

    public MedicareTaxRepository(IDapperContext context)
    {
        _context = context;
    }

    public async Task<MedicareTaxTable> GetMedicareTaxPercentage(DateOnly date)
    {
        string query = "SELECT " +
                       "Tax_Rate AS TaxRate, " +
                       "Additional_Tax_Rate AS AdditionalTaxRate, " +
                       "Threshold_Wage AS ThresholdWage " +
                       "FROM Medicare_Tax_Table " +
                       $"WHERE YEAR(Tax_Year) = {date.Year}";
        using IDbConnection connection = _context.CreateConnection();
        MedicareTaxTable medicareTaxTable = await connection.QueryFirstOrDefaultAsync<MedicareTaxTable>(query);
        return medicareTaxTable;
    }
}