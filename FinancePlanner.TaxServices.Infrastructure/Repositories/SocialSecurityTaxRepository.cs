using System;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using FinancePlanner.TaxServices.Domain.Entities;
using FinancePlanner.TaxServices.Infrastructure.Persistence;

namespace FinancePlanner.TaxServices.Infrastructure.Repositories;

public class SocialSecurityTaxRepository : ISocialSecurityTaxRepository
{
    private readonly IDapperContext _context;

    public SocialSecurityTaxRepository(IDapperContext context)
    {
        _context = context;
    }

    public async Task<SocialSecurityTaxTable> GetSocialSecurityTaxPercentage(DateOnly date)
    {
        string query = "SELECT " +
                       "Tax_Rate AS TaxRate, " +
                       "Wage_Base_Limit AS WageBaseLimit " +
                       "FROM Social_Security_Tax_Table " +
                       $"WHERE YEAR(Tax_Year) = {date.Year}";
        using IDbConnection connection = _context.CreateConnection();
        SocialSecurityTaxTable socialSecurityTaxTable = await connection.QueryFirstOrDefaultAsync<SocialSecurityTaxTable>(query);
        return socialSecurityTaxTable;
    }
}