using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using StoreApp.Entity.Entities;
using StoreApp.Extensions;
using StoreApp.Service.Services.Abstractions;

namespace StoreApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IHttpContextAccessor httpContextAccessor;
        public Cart cart => httpContextAccessor.HttpContext.Session.GetJson<Cart>("cart") ?? new();


        public OrderController(IOrderService orderService, IHttpContextAccessor httpContextAccessor)
        {
            this.orderService = orderService;
            this.httpContextAccessor = httpContextAccessor;
        }


        [HttpGet]
        public ViewResult Checkout() => View(new Order());

        [HttpPost]
        public IActionResult CheckOut(Order order)
        {

            
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Hata");
            }

            if (ModelState.IsValid)
            {

                string cityName = Request.Form["CityName"];
                order.City = cityName;
                order.CartLines = cart.Lines.ToArray();
                orderService.SaveOrder(order);
                cart.Clear();
                return RedirectToPage("/Complete", new { Id = order.Id });
            }
            return View();
        }
    }
}
