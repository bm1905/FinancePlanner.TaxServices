using System;
using System.Threading.Tasks;
using FinancePlanner.Shared.Models.Enums;
using FinancePlanner.Shared.Models.Exceptions;
using FinancePlanner.Shared.Models.TaxServices;
using FinancePlanner.TaxServices.Application.Constants;
using FinancePlanner.TaxServices.Domain.Entities;
using FinancePlanner.TaxServices.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using TaxServices.Plugins.FedTax.W4FromOrAfter2020.Models;

namespace TaxServices.Plugins.FedTax.W4FromOrAfter2020;

public class TaxCalculatorManager
{
    private readonly IFederalTaxRepository _federalTaxBracketRepository;

    public TaxCalculatorManager(IFederalTaxRepository federalTaxBracketRepository)
    {
        _federalTaxBracketRepository = federalTaxBracketRepository;
    }

    internal W4FromOrAfter2020Model GetModel(CalculateTaxWithheldRequest model)
    {
        bool? multipleJobs = model.TaxInformation.IsMultipleJobsChecked;
        if (multipleJobs == null)
        {
            throw new BadRequestException("Invalid IsMultipleJobsChecked passed in request");
        }

        decimal extraWithholding = model.TaxInformation.ExtraWithholdingAmount;
        decimal? deductions = model.TaxInformation.DeductionsAmount;
        if (deductions == null)
        {
            throw new BadRequestException("Invalid deduction amount passed in request");
        }
        decimal? otherIncome = model.TaxInformation.OtherIncomeAmount;
        if (otherIncome == null)
        {
            throw new BadRequestException("Invalid OtherIncome passed in request");
        }
        decimal? claimDependentsAmount = model.TaxInformation.ClaimDependentsAmount;
        if (claimDependentsAmount == null)
        {
            throw new BadRequestException("Invalid ClaimDependentsAmount passed in request");
        }

        W4FromOrAfter2020Model w4FromOrAfter2020Model = new W4FromOrAfter2020Model
        {
            TaxableWage = model.TaxableWageInformation.StateAndFederalTaxableWages,
            PayPeriodNumber = model.TaxInformation.PayPeriodNumber,
            TaxFilingStatus = model.TaxInformation.TaxFilingStatus,
            W4Type = nameof(W4Type.W4FromOrAfter2020),
            ClaimDependentsAmount = (decimal)claimDependentsAmount,
            Deductions = (decimal)deductions,
            ExtraWithholding = extraWithholding,
            IsMultipleJobsChecked = (bool)multipleJobs,
            OtherIncome = (decimal)otherIncome
        };

        return w4FromOrAfter2020Model;
    }

    internal decimal GetAdjustedAnnualWage(W4FromOrAfter2020Model w4FromOrAfter2020Model, IConfiguration config)
    {
        try
        {
            decimal _1c = w4FromOrAfter2020Model.TaxableWage * w4FromOrAfter2020Model.PayPeriodNumber;
            decimal _1d = w4FromOrAfter2020Model.OtherIncome;
            decimal _1e = _1c + _1d;
            decimal _1f = w4FromOrAfter2020Model.Deductions;
            decimal _1g;
            if (w4FromOrAfter2020Model.IsMultipleJobsChecked)
            {
                _1g = 0;
            }
            else if (w4FromOrAfter2020Model.TaxFilingStatus == TaxFilingStatus.MarriedFilingJointly)
            {
                _1g = int.Parse(config.GetSection("W4Config:W4FromOrAfter2020:MarriedFilingJointly_1g").Value ?? "12900");
            }
            else
            {
                _1g = int.Parse(config.GetSection("W4Config:W4FromOrAfter2020:Otherwise_1g").Value ?? "8600");
            }
            decimal _1h = _1f + _1g;
            decimal _1i = _1e - _1h;
            if (_1i < 0) _1i = 0;
            return _1i;
        }
        catch (Exception ex)
        {
            throw new InternalServerErrorException("Something went wrong while calculating Adjusted Annual Wage.", ex);
        }
    }

    internal async Task<decimal> GetFederalTaxWithheldAmount(W4FromOrAfter2020Model w4FromOrAfter2020Model, decimal adjustedAnnualWage)
    {
        try
        {
            string tableName = w4FromOrAfter2020Model.TaxFilingStatus switch
            {
                TaxFilingStatus.MarriedFilingJointly => TaxMethodTables.MarriedFiledJointlyW4Before2020,
                TaxFilingStatus.SingleOrMarriedFilingSingle => TaxMethodTables.SingleOrMarriedFiledSeparatelyW4Before2020,
                TaxFilingStatus.HeadOfHousehold => TaxMethodTables.HeadOfHouseholdW4Before2020,
                _ => string.Empty,
            };

            PercentageMethodTable percentageMethodTable = await _federalTaxBracketRepository.GetFederalTaxPercentage(adjustedAnnualWage, tableName);

            decimal _2b = percentageMethodTable.AtLeast;
            decimal _2c = percentageMethodTable.TentativeHoldAmount;
            decimal _2d = percentageMethodTable.Percentage;
            decimal _2e = adjustedAnnualWage - _2b;
            decimal _2f = _2e * _2d / 100;
            decimal _2g = _2c + _2f;
            decimal _2h = _2g / w4FromOrAfter2020Model.PayPeriodNumber;
            decimal _3a = w4FromOrAfter2020Model.ClaimDependentsAmount;
            decimal _3b = _3a / w4FromOrAfter2020Model.PayPeriodNumber;
            decimal _3c = _2h - _3b;
            if (_3c < 0) _3c = 0;
            decimal _4a = w4FromOrAfter2020Model.ExtraWithholding;
            decimal _4b = _3c + _4a;
            return _4b;
        }
        catch (Exception ex)
        {
            throw new InternalServerErrorException($"Something went wrong while calculating Federal Tax Withheld Amount. {ex.Message}", ex);
        }
    }
}