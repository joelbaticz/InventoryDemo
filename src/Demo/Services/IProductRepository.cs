using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Demo.Models;

namespace Demo.Services
{
    public interface IProductRepository:IRepository<Product>
    {
    }
}
