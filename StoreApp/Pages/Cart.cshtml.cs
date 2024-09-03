using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreApp.Entity.Entities;
using StoreApp.Extensions;
using StoreApp.Service.Services.Abstractions;

namespace StoreApp.Pages
{
    public class CartModel : PageModel
    {
        private readonly IProductService productService;
        private readonly IHttpContextAccessor httpContextAccessor;

        public Cart Cart { get; set; }

        public CartModel(IProductService productService, IHttpContextAccessor httpContextAccessor)
        {
            this.productService = productService;
            this.httpContextAccessor = httpContextAccessor;
        }


        public string ReturnUrl { get; set; } = "/";

        public void OnGet(string returnUrl)
        {

            ReturnUrl = returnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(Guid Id, string returnUrl)
        {

            Product product = productService.GetByProduct(Id);
            if (product is not null)
            {
                Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(product, 1);
                HttpContext.Session.SetJson<Cart>("cart", Cart);
            }

            return Page();
        }

        public IActionResult OnPostRemove(Guid Id, string returnUrl)
        {
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            Cart.RemoveLine(Cart.Lines.First(x => x.Product.Id.Equals(Id)).Product);
            HttpContext.Session.SetJson<Cart>("cart", Cart);
            return Page();
        }
    }
}
