using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Demo.Models;

namespace Demo.ViewModels
{
    public class DisplayAllCategoriesViewModel
    {
        public IEnumerable<Category> Categories { get; set; }

    }
}
