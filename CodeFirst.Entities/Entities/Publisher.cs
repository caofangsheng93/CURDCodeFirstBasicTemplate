using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Entities.Entities
{
    /// <summary>
    /// 出版方
    /// </summary>
   public class Publisher
    {
       public int PublisherId { get; set; }

       public string PublisherName { get; set; }

       public string Address { get; set; }

       public virtual ICollection<Book> Books { get; set; }

    }
}
