using Microsoft.EntityFrameworkCore;
using StoreApp.Core.EntityBase;
using StoreApp.Data.Context;
using StoreApp.Data.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace StoreApp.Data.Repositories.Concretions
{
    public class Repository<T> : IRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext appDbContext;

        public Repository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        DbSet<T> Table { get => appDbContext.Set<T>(); }

        public void Add(T entity)
        {
            Table.Add(entity);
        }

        public void SafeDelete(T entity)
        {
            Table.Update(entity);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;
            if (predicate != null)
                query = query.Where(predicate);
            if (includeProperties.Any())
                foreach (var item in includeProperties)
                    query = query.Include(item);
            return query;
        }

        public T GetBy(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;
            query = query.Where(predicate);
            if (includeProperties.Any())
                foreach (var item in includeProperties)
                    query = query.Include(item);
            return query.SingleOrDefault();
        }

        public void Update(T entity)
        {
            Table.Update(entity);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate is not null)
            {
                return await Table.CountAsync(predicate);
            }
            return await Table.CountAsync();
        }
    }
}
