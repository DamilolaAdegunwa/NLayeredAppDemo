using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JamesAlcaraz.NlayeredAppDemo.Core.Entities;

namespace JamesAlcaraz.NlayeredAppDemo.EntityFramework.EntityConfig
{
    public class SalesOrderMap : EntityTypeConfiguration<SalesOrder>
    {
        public SalesOrderMap()
        {
            this.ToTable("SalesOrder", "Sales");

            //Primary key and joins already set using conventions

        }
    }
}
