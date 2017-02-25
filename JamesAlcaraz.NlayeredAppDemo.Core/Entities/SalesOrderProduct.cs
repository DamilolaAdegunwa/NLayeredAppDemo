using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JamesAlcaraz.NlayeredAppDemo.Core.Entities.Spefications;

namespace JamesAlcaraz.NlayeredAppDemo.Core.Entities
{
    public class SalesOrderProduct : EntityAudited
    {
        public int SalesOrderId { get; set; }
        public int ProductId { get; set; }
        public int QuantityOrdered { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual Product Product { get; set; }
        public virtual SalesOrder SalesOrder { get; set; }

    }
}
