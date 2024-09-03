using Microsoft.AspNetCore.Mvc;
using StoreApp.Entity.Entities;
using StoreApp.Extensions;

namespace StoreApp.ViewComponents
{
    public class CartSummaryViewComponent : ViewComponent
    {
        public Cart cart => HttpContext.Session.GetJson<Cart>("cart")??new();
        public string Invoke()
        {
            return cart.Lines.Count.ToString();
        }
    }
}
