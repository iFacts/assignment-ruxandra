using SalesTaxCalculator.BusinessEntities.Enums;

namespace SalesTaxCalculator.BusinessEntities.Settings
{
    public class SaleTaxRuleSettings : TaxRuleSettings
    {
        public List<Category> ExcludedCategories { get; set; } = [];
    }
}
