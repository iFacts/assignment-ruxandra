using SalesTaxCalculator.BusinessEntities.Models;

namespace SalesTaxCalculator.BusinessLogic.Interfaces
{
    public interface ITaxRule
    {
        public bool IsRuleApplicable(Item item);
        public decimal CalculateTax(Item item);
    }
}
