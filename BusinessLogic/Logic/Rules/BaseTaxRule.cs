using SalesTaxCalculator.BusinessLogic.Interfaces;
using SalesTaxCalculator.BusinessEntities.Models;
using SalesTaxCalculator.BusinessEntities.Settings;

namespace SalesTaxCalculator.BusinessLogic.Logic.Rules
{
    public abstract class BaseTaxRule : ITaxRule
    {
        protected TaxRuleSettings RuleSetting{ get; set; }

        public BaseTaxRule(TaxRuleSettings ruleSetting)
        {
            RuleSetting = ruleSetting;
        }

        public abstract bool IsRuleApplicable(Item item);

        public decimal CalculateTax(Item item)
            => item.Price * RuleSetting.TaxAmount;
    }
}
