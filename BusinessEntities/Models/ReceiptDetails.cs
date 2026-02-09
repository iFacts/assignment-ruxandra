namespace SalesTaxCalculator.BusinessEntities.Models
{
    public class ReceiptDetails
    {
        public List<ReceiptItem> ReceiptItems { get; set; } = [];
        public decimal SalesTax { get; set; }
        public decimal Total { get; set; }
    }
}
