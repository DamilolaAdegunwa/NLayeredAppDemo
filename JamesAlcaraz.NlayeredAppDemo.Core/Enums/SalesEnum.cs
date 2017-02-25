using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamesAlcaraz.NlayeredAppDemo.Core.Enums
{
    public enum SalesOrderStatusEnum : short
    {
        InProcess = 1,
        Approved = 2,
        Backordered = 3,
        Rejected = 4,
        Shipped = 5,
        Cancelled = 6
    }
}
