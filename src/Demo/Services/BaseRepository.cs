using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Demo.Services;
using System.Linq.Expressions;


namespace Demo.Services
{
    //Add abstract
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {

        private MyDbContext _context;
        private DbSet<T> _dbSet;

        public BaseRepository()
        {
            _context = new MyDbContext();
            _dbSet = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Create(T entity)
        {
            _dbSet.Add(entity);
            //Commit changes
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            //Commit changes
            _context.SaveChanges();
        }

        public T GetSingle(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public IEnumerable<T> Query(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public void Update(T entity)
        {
            //In EF there is no update
            //We just change the state of the object
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();

        }

    }
}
