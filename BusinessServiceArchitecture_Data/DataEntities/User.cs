using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServiceArchitecture_Data.DataEntities
{
    public class User: BaseEntity
    {
        public String Name { get; set; }

        public String Email { get; set; }

        public bool IsActive { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}
