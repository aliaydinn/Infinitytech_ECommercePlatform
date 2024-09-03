using Microsoft.AspNetCore.Mvc;
using StoreApp.Entity.DTOs;
using StoreApp.Entity.Entities;
using StoreApp.Extensions;
using StoreApp.Service.Services.Abstractions;
using StoreApp.Service.Services.Concretions;

namespace StoreApp.Controllers
{
    [Route("cart")]
    public class CartController : Controller
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IProductService productService;

        public CartController(IHttpContextAccessor httpContextAccessor,IProductService productService)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.productService = productService;
        }
        [HttpPost("update")]
        public IActionResult UpdateCart([FromBody] List<CartLineDto> cartLines)
        {
            var cart = httpContextAccessor.HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            foreach (var line in cartLines)
            {
                var product = productService.GetByProduct(line.ProductId); // Burada product değişkeni kullanılıyor
                if (product != null)
                {
                    cart.UpdateItemQuantity(product, line.Quantity);
                }
            }

            httpContextAccessor.HttpContext.Session.SetJson("cart", cart);
            return Json(new { success = true });
        }

    }
}
