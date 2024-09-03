using StoreApp.Core.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Data.Repositories.Abstractions
{
    public interface IRepository<T> where T : class,IEntityBase, new()
    {
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
        T GetBy(Expression<Func<T, bool>> predicate=null ,params Expression<Func<T, object>>[] inculudeProperties);
        void Add(T entity);
        void Update(T entity);
        void SafeDelete(T entity);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate = null);


    }
}
