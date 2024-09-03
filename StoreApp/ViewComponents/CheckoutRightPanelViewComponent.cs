using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Entity.Entities;
using StoreApp.Extensions;
using StoreApp.Service.Services.Abstractions;

namespace StoreApp.ViewComponents
{
    public class CheckoutRightPanelViewComponent : ViewComponent
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public CheckoutRightPanelViewComponent(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public IViewComponentResult Invoke()
        {
            var cart = httpContextAccessor.HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            return View(cart);
        }
    }

}
