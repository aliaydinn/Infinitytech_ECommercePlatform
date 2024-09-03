using Microsoft.EntityFrameworkCore;
using StoreApp.Data.Context;
using StoreApp.Data.UnitOfWorks;
using StoreApp.Entity.Entities;
using StoreApp.Service.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Service.Services.Concretions
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly AppDbContext appDbContext;

        public OrderService(IUnitOfWork unitOfWork,AppDbContext appDbContext)
        {
            this.unitOfWork = unitOfWork;
            this.appDbContext = appDbContext;
        }


        public void Complate(Guid id)
        {
            var order = unitOfWork.GetRepository<Order>().GetBy(x=>x.Id.Equals(id));
            if (order is null)
            {
                throw new Exception("Order is not found");
            }
            order.Shipment = true;
            unitOfWork.GetRepository<Order>().Update(order);
            unitOfWork.Save();
        }
        public IQueryable<Order> GetAllOrders()
        {
            var orders = unitOfWork.GetRepository<Order>()
        .GetAll(null, a => a.CartLines)
        .Include("CartLines.Product");

            return orders;
        }


        public Order GetOrder(Guid id)
        {
            var order = unitOfWork.GetRepository<Order>().GetBy(x=>x.Id.Equals(id));
            return order;
        }

        public void SaveOrder(Order order)
        {
            appDbContext.AttachRange(order.CartLines.Select(x => x.Product));
            unitOfWork.GetRepository<Order>().Add(order);
            unitOfWork.Save();
        }
    }
}

