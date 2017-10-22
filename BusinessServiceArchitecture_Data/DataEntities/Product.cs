using System.Collections.Generic;

namespace BusinessServiceArchitecture_Data.DataEntities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }

        public decimal StockLevel { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}