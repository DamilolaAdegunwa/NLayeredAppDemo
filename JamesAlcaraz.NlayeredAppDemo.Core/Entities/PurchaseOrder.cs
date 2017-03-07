using JamesAlcaraz.NlayeredAppDemo.Core.Entities.Spefications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamesAlcaraz.NlayeredAppDemo.Core.Entities
{
    public class PurchaseOrder : EntityAudited
    {
        public int QuantityOrdered { get; set; }
        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
