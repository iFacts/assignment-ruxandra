using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SalesTaxCalculator.BusinessEntities.Settings;
using SalesTaxCalculator.BusinessLogic.Interfaces;
using SalesTaxCalculator.BusinessLogic.Logic.Rules;

namespace SalesTaxCalculator.WebApi.Extensions
{
    public static class ServicesExtensions
    {
        public static void RegisterSettings(this IServiceCollection services, IConfigurationRoot configuration)
        {
            var taxConfig = configuration.GetSection("TaxRules");

            var saleTaxSettings = taxConfig.GetSection("SaleTaxRule").Get<SaleTaxRuleSettings>();
            if (saleTaxSettings == null)
            {
                throw new Exception("SaleTaxRule settings are missing in the configuration.");
            }
            services.AddSingleton(saleTaxSettings);

            var importedTaxSettings = taxConfig.GetSection("ImportedTaxRule").Get<ImportedTaxRuleSettings>();
            if (importedTaxSettings == null)
            {
                throw new Exception("ImportedTaxRule settings are missing in the configuration.");
            }
            services.AddSingleton(importedTaxSettings);

            var salesTaxCalculatorSettings = configuration.GetSection("SalesTaxCalculator").Get<SalesTaxCalculatorSettings>();
            if (salesTaxCalculatorSettings == null)
            {
                throw new Exception("SalesTaxCalculator settings are missing in the configuration.");
            }
            services.AddSingleton(salesTaxCalculatorSettings);
        }

        public static void RegisterRules(this IServiceCollection services)
        {
            services.AddSingleton<ITaxRule, ImportedTaxRule>();
            services.AddSingleton<ITaxRule, SaleTaxRule>();
        }

        public static void RegisterCalculators(this IServiceCollection services)
        {
            services.AddSingleton<ISalesTaxCalculator, BusinessLogic.Logic.SalesTaxCalculator>();
        }
    }
}
