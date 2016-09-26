using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Linq.Expressions;

namespace Demo.Services
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        void Create(T entity);

        void Update(T entity);

        //You can return boolean if you want!
        void Delete(T Entity);

        //Get Single entity by anything
        //GetById, GetByPrice will be replaced by:
        //Using predicate (any lambda expression)
        T GetSingle(Expression<Func<T, bool>> predicate);

        //The multiple version of this:
        IEnumerable<T> Query(Expression<Func<T, bool>> predicate);
    }

    

}
