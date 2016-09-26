using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Demo.Models;
using Demo.Services;

namespace Demo.Services
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {

    }

}
