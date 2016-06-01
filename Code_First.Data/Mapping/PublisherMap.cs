using CodeFirst.Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_First.Data.Mapping
{
   public class PublisherMap:EntityTypeConfiguration<Publisher>
    {
       public PublisherMap()
       {
           //配置主键
           this.HasKey(s => s.PublisherId);

           //配置字段
           this.Property(s => s.PublisherId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
           this.Property(s => s.Address).IsRequired().HasColumnType("nvarchar");
           this.Property(s => s.PublisherName).IsRequired().HasColumnType("nvarchar");

           //this.HasRequired(s=>s.Books).
           this.ToTable("Publishers");

       }
    }
}
