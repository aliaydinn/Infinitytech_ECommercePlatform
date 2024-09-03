using StoreApp.Core.EntityBase;
using StoreApp.Data.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Data.UnitOfWorks
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<T> GetRepository<T>() where T: class,IEntityBase,new();
        void Save();
    }
}
