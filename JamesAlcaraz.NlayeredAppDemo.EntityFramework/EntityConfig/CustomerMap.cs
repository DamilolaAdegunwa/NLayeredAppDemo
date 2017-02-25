using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JamesAlcaraz.NlayeredAppDemo.Core.Entities;

namespace JamesAlcaraz.NlayeredAppDemo.EntityFramework.EntityConfig
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            this.ToTable("Customer", "Customers");

            //Primary key and joins already set using conventions

            this.Property(x => x.CompanyName)
                .IsRequired()
                .HasMaxLength(128);
        }
    }
}
