namespace SalesTaxCalculator.BusinessEntities.Models
{
    public class ReceiptItem : Item
    {
        public decimal PriceIncludingSalesTax { get; set; }

        public ReceiptItem(Item item, decimal priceIncludingSalesTax)
            : base(item.Name, item.Price, item.Category, item.IsImported)
        {
            PriceIncludingSalesTax = priceIncludingSalesTax;
        }
    }
}
