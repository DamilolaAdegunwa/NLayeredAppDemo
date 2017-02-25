using System;
using System.Collections.Generic;
using JamesAlcaraz.NlayeredAppDemo.Core.Entities.Spefications;

namespace JamesAlcaraz.NlayeredAppDemo.Core.Entities
{
    public class SalesOrder : EntityAudited
    {
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public short StatusId { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual SalesOrderStatus Status { get; set; }

        public virtual ICollection<SalesOrderProduct> OrderDetails { get; set; }
    }
}
