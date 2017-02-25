using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JamesAlcaraz.NlayeredAppDemo.Core.Entities;

namespace JamesAlcaraz.NlayeredAppDemo.EntityFramework.EntityConfig
{
    public class SalesOrderStatusMap : EntityTypeConfiguration<SalesOrderStatus>
    {
        public SalesOrderStatusMap()
        {
            this.ToTable("SalesOrderStatus", "Lookups");

            //Primary key and joins already set using conventions

            this.Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(64);
        }
    }
}
