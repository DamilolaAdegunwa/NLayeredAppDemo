using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JamesAlcaraz.NlayeredAppDemo.Core.Entities.Spefications;

namespace JamesAlcaraz.NlayeredAppDemo.Core.Entities
{
    public class Customer : Entity
    {
        public string CompanyName { get; set; }

        public virtual ICollection<SalesOrder> SalesOrders { get; set; }
    }
}
