using CommunityProApp.Context;
using CommunityProApp.Entities;
using CommunityProApp.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CommunityProApp.Implementations.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity, new()
    {
        protected ApplicationContext _context;
        public T Create(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
            return entity;
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

       
        public T Get(int id)
        {
            return _context.Set<T>().SingleOrDefault(e => e.Id == id);
        }

        public IEnumerable<T> Get(IList<int> ids)
        {
            return _context.Set<T>().Where(d => ids.Contains(d.Id)).ToList();
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().SingleOrDefault(expression);
        }

        public IEnumerable<T> Get()
        {
            return _context.Set<T>().ToList();
        }

        public IList<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).ToList();
        }

        public bool Exists(int id)
        {
            return _context.Set<T>().Any(d => d.Id == id);
        }

        public bool Exists(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Any(expression); 
        }

        public IEnumerable<T> Create(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Query()
        {
            return _context.Set<T>().AsQueryable();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }


        public T Get(string name)
        {
            throw new NotImplementedException();
        }
    }
}
