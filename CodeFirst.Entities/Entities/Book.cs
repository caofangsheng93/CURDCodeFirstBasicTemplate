using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeFirst.Entities.Entities
{
    /// <summary>
    /// 图书类
    /// </summary>
   public class Book
    {
       public int BookId { get; set; }

       public string Title { get; set; }

       public string Year { get; set; }

       public int PublisherId { get; set; }

       public virtual Publisher Publisher { get; set; }
    }
}
