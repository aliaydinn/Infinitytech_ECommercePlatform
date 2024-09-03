using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Entity.Entities;
using StoreApp.Extensions;
using StoreApp.Service.Services.Abstractions;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public IActionResult Index()
        {
            var orders=orderService.GetAllOrders();
            return View(orders);
        }
    }
}
