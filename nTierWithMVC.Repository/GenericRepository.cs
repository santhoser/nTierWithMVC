﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nTierWithMVC.DAL;

namespace nTierWithMVC.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected nTierWithMVCContext _context;

        public GenericRepository(IUnitOfWork unitOfWork)
        {
            _context = unitOfWork.DbContext;
        }
                
        public IQueryable<T> GetAll()
        {
            IQueryable<T> query = _context.Set<T>();
            return query;
        }

        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

    }
}
