using SalesTaxCalculator.BusinessEntities.Enums;

namespace SalesTaxCalculator.BusinessEntities.Models
{
    public class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public bool IsImported { get; set; }

        public Item(
            string name,
            decimal price, 
            Category category = Category.None,
            bool isImported = false
            )
        {
            Name = name;
            Price = price;
            Category = category;
            IsImported = isImported;
        }
    }
}
