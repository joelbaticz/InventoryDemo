using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class Category
    {
        //class name + Id will be the PK in the DB
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //relationship
        public List<Product> Products { get; set; }

    }
}
