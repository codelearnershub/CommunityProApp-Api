using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CommunityProApp.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        T Create(T entity);
        T Update(T entity);
        void Delete(T entity);
        T Get(int id);
        T Get(string name);
        IEnumerable<T> Get();
        IEnumerable<T> Get(IList<int> ids);
        T Get(Expression<Func<T, bool>> expression);     
        IList<T> GetAll(Expression<Func<T, bool>> expression);
        bool Exists(int id);
        bool Exists(Expression<Func<T, bool>> expression);
        IEnumerable<T> Create(IEnumerable<T> entities);
        IQueryable<T> Query();
        int SaveChanges();
    }
}
