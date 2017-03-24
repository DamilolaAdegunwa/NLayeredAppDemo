using System;
using System.Collections.Generic;
using JamesAlcaraz.NlayeredAppDemo.Core.Entities.Spefications;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

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

        [NotMapped]
        public decimal SubTotal {
            get {
                var result = 0M;
                if (OrderDetails != null && OrderDetails.Any())
                    result = OrderDetails.Sum(x => x.QuantityOrdered * x.UnitPrice);

                return result;
            }
        }


    }
}
