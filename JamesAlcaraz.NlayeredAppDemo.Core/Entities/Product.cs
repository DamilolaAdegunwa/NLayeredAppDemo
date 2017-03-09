using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JamesAlcaraz.NlayeredAppDemo.Core.Entities.Spefications;

namespace JamesAlcaraz.NlayeredAppDemo.Core.Entities
{
    public class Product: EntityAudited
    {
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual ICollection<SalesOrderProduct> Orders { get; set; }

        //public virtual Ius CreatedBy { get; set; }//
    }
}
