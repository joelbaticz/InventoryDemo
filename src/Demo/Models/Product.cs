using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public double Price { get; set; }

        //relationship
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        

    }
}
