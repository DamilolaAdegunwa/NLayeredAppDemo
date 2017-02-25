using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JamesAlcaraz.NlayeredAppDemo.Core.Entities;

namespace JamesAlcaraz.NlayeredAppDemo.EntityFramework.EntityConfig
{
    public class SalesOrderProductMap : EntityTypeConfiguration<SalesOrderProduct>
    {
        public SalesOrderProductMap()
        {
            this.ToTable("SalesOrderProduct", "Sales");

            //Primary key and joins already set using conventions
        }
    }
}
