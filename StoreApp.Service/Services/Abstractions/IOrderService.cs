using StoreApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Service.Services.Abstractions
{
    public interface IOrderService
    {
        IQueryable<Order> GetAllOrders();
        Order GetOrder(Guid id);
        void Complate(Guid id);
        void SaveOrder(Order order);


    }
}
