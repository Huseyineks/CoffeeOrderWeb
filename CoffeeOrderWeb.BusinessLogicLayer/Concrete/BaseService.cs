using CoffeeOrderWeb.BusinessLogicLayer.Abstract;
using CoffeeOrderWeb.DataAccesLayer.Abstract;
using CoffeeOrderWeb.DataAccesLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeOrderWeb.BusinessLogicLayer.Concrete
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IBaseRepository<T> _baseRepository;
        public BaseService(IBaseRepository<T> baseRepository) { 
        
            _baseRepository = baseRepository;
         
        }
        public void Add(T entity)
        {
            _baseRepository.Add(entity);
        }

        public void Remove(T entity)
        {
            _baseRepository.Remove(entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _baseRepository.Get(filter);
        }

        public List<T> GetAll()
        {
            return _baseRepository.GetAll();
        }

        public List<T> GetClassifiedList(Expression<Func<T,bool>> filter)
        {
            return _baseRepository.GetClassifiedList(filter);
        }

        public void Save()
        {
            _baseRepository.Save();
        }

        public void Update(T entity)
        {
            _baseRepository.Update(entity);
        }
    }
}
