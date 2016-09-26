using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Demo.Models;

namespace Demo.ViewModels
{
    public class DisplayCategoryViewModel
    {
        public int CatId { get; set; }
        public string CatName { get; set; }
        public string Description { get; set; }
        public IEnumerable<Product> CatProducts { get; set; }
    }
}

