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
   public class BookMap:EntityTypeConfiguration<Book>
    {
       public BookMap()
       {
           //配置主键
           this.HasKey(s => s.BookId);

           //配置字段
           this.Property(s => s.BookId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
           this.Property(s => s.Title).IsRequired();
           this.Property(s => s.Year).IsRequired();

           //配置关系
           this.HasRequired(s => s.Publisher).WithMany(s => s.Books).HasForeignKey(s => s.PublisherId);

           //配置表
           ToTable("Books");

       }
    }
}
