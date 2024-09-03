using StoreApp.Core.EntityBase;
using StoreApp.Data.Context;
using StoreApp.Data.Repositories.Abstractions;
using StoreApp.Data.Repositories.Concretions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext appDbContext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public void Dispose()
        {
           appDbContext.Dispose();
        }

        public IRepository<T> GetRepository<T>() where T : class,IEntityBase, new()
        {
           return new Repository<T>(appDbContext);
        }

        public void Save()
        {
            appDbContext.SaveChanges();
        }
    }
}
