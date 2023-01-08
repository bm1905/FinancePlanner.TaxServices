using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using FinancePlanner.TaxServices.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Dapper;
using Microsoft.Extensions.Logging;

namespace FinancePlanner.TaxServices.Services.Initializer
{
    public class DbInitializer
    {
        public static async Task<bool> EnsureSeedData(WebApplication app)
        {
            try
            {
                using IServiceScope scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
                IDapperContext? context = scope.ServiceProvider.GetService<IDapperContext>();
                if (context == null) throw new Exception("Null Database Context");
                using IDbConnection connection = context.CreateConnection();

                List<string> tables = new List<string>()
                {
                    "dbo.Medicare_Tax_Table",
                    "dbo.Percentage_Method_Table_O1_HoH",
                    "dbo.Percentage_Method_Table_O1_MFJ",
                    "dbo.Percentage_Method_Table_O1_SorMFS",
                    "dbo.Percentage_Method_Table_O2_HoH",
                    "dbo.Percentage_Method_Table_O2_MFJ",
                    "dbo.Percentage_Method_Table_O2_SorMFS",
                    "dbo.Social_Security_Tax_Table",
                    "dbo.Tax_Filing_Status",
                };

                foreach (string table in tables)
                {
                    try
                    {
                        int count = await connection.QuerySingleAsync<int>(
                            $"select count(1) where exists (select * from {table})");
                        if (count > 0) continue;
                        await ExecuteQuery(connection);
                    }
                    catch (Exception ex)
                    {
                        app.Logger.LogError($"Unable to query existing database; Recreating all tables. {ex}");
                        await ExecuteQuery(connection);
                    }

                    return true;
                }

                return true;
            }
            catch (Exception ex)
            {
                app.Logger.LogError($"Seeding database failed withe exception {ex}");
                return false;
            }
        }

        private static async Task ExecuteQuery(IDbConnection connection)
        {
            string path = Directory.GetCurrentDirectory();
            string script = await File.ReadAllTextAsync(@$"{path}\\Initializer\\SQL-Script.sql");
            await connection.ExecuteAsync(script);
        }
    }
}
