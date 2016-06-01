using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Code_First_CURD.Models
{
    public class PublisherBookModel
    {
        public int ID { get; set; }

        public string PublisherName { get; set; }

        public string Address { get; set; }

        public string Title { get; set; }
       
        public string Year { get; set; }    
    }
}