using SalesTaxCalculator.BusinessEntities.Models;

namespace SalesTaxCalculator.BusinessLogic.Interfaces
{
    public interface ISalesTaxCalculator
    {
        ReceiptDetails Process(params Item[] items);
    }
}
