using SalesTaxCalculator.BusinessEntities.Models;
using SalesTaxCalculator.BusinessEntities.Settings;

namespace SalesTaxCalculator.BusinessLogic.Logic.Rules
{
    public class SaleTaxRule : BaseTaxRule
    {
        public SaleTaxRule(SaleTaxRuleSettings ruleSetting) : base(ruleSetting)
        {
        }

        public override bool IsRuleApplicable(Item item)
            => !((SaleTaxRuleSettings)RuleSetting).ExcludedCategories.Contains(item.Category);
    }
}
