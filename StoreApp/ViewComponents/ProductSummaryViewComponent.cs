using Microsoft.AspNetCore.Mvc;
using StoreApp.Service.Services.Abstractions;

namespace StoreApp.ViewComponents
{
    public class ProductSummaryViewComponent : ViewComponent
    {
        private readonly IProductService productService;

        public ProductSummaryViewComponent(IProductService productService)
        {
            this.productService = productService;
        }
        public string Invoke()
        {
            return productService.GetAllProduct().Count().ToString();
        }
    }
}
