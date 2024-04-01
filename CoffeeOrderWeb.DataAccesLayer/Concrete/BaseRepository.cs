using CoffeeOrderWeb.DataAccesLayer.Abstract;
using CoffeeOrderWeb.DataAccesLayer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeOrderWeb.DataAccesLayer.Concrete
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> _dbSet;
        public BaseRepository(ApplicationDbContext db) { 
        
            _db = db;
            _dbSet = _db.Set<T>();
        
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = _dbSet.Where(filter);

            return query.FirstOrDefault();
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public List<T> GetClassifiedList(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = _dbSet.Where(filter);

            return query.ToList();
        }

        public void Save()
        {
           _db.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
