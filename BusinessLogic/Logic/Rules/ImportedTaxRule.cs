using SalesTaxCalculator.BusinessEntities.Models;
using SalesTaxCalculator.BusinessEntities.Settings;

namespace SalesTaxCalculator.BusinessLogic.Logic.Rules
{
    public class ImportedTaxRule : BaseTaxRule
    {
        public ImportedTaxRule(ImportedTaxRuleSettings ruleSetting) : base(ruleSetting)
        {
        }

        public override bool IsRuleApplicable(Item item)
            => item.IsImported;
    }
}