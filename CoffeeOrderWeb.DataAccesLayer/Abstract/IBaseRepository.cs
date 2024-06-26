﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeOrderWeb.DataAccesLayer.Abstract
{
    public interface IBaseRepository<T> where T : class
    {
        void Add(T entity);

        void Update(T entity);

        void Remove(T entity);

        void Save();

        List<T> GetAll();

        List<T> GetClassifiedList(Expression<Func<T,bool>> filter);

        T Get(Expression<Func<T,bool>> filter);

    }
}
