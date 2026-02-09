using SalesTaxCalculator.BusinessLogic.Interfaces;
using SalesTaxCalculator.BusinessEntities.Models;
using SalesTaxCalculator.BusinessEntities.Settings;

namespace SalesTaxCalculator.BusinessLogic.Logic
{
    public class SalesTaxCalculator : ISalesTaxCalculator
    {
        private readonly SalesTaxCalculatorSettings _settings;
        private readonly IEnumerable<ITaxRule> _taxRules;

        public SalesTaxCalculator(IEnumerable<ITaxRule> taxRules, SalesTaxCalculatorSettings settings)
        {
            _taxRules = taxRules;
            _settings = settings;
        }

        private decimal CalculateItemTax(Item item)
            => _taxRules
                .Where(rule => rule.IsRuleApplicable(item))
                .Sum(rule => rule.CalculateTax(item));

        public ReceiptDetails Process(params Item[] items)
        {
            var receiptDetails = new ReceiptDetails();

            foreach (var item in items)
            {
                var taxAmount = CalculateItemTax(item);
                var priceIncludingTax = item.Price + taxAmount;

                receiptDetails.ReceiptItems.Add(new ReceiptItem(item, RoundNumber(priceIncludingTax)));

                receiptDetails.SalesTax += taxAmount;
                receiptDetails.Total += priceIncludingTax;
            }

            receiptDetails.SalesTax = RoundNumber(receiptDetails.SalesTax);
            receiptDetails.Total = RoundNumber(receiptDetails.Total);

            return receiptDetails;
        }

        private decimal RoundNumber(decimal amount)
            => Math.Round(amount, _settings.NumberOfDecimalPlaces, MidpointRounding.AwayFromZero);
    }
}
