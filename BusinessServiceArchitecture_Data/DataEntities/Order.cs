using System;
using System.Collections.Generic;

namespace BusinessServiceArchitecture_Data.DataEntities
{
    public class Order:BaseEntity
    {
        public DateTime OrderDate { get; set; }

        public float OrderTotalPrice { get; set; }

        public User User { get; set; }

        public ICollection<Product> ProductList { get; set; }
    }
}