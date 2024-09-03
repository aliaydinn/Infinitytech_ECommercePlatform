using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Data.UnitOfWorks;
using StoreApp.Entity.Entities;
using StoreApp.Service.Services.Abstractions;

namespace StoreApp.ViewComponents
{
    public class ProductFilterViewComponent : ViewComponent
    {
        private readonly IProductService productService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IUnitOfWork unitOfWork;

        public ProductFilterViewComponent(IProductService productService,IHttpContextAccessor httpContextAccessor,IUnitOfWork unitOfWork)
        {
            this.productService = productService;
            this.httpContextAccessor = httpContextAccessor;
            this.unitOfWork = unitOfWork;
        }
        public IViewComponentResult Invoke()
        {
            var recentlyViewedProducts = GetRecentlyViewedProducts();
            return View(recentlyViewedProducts);
        }

        public List<Product> GetRecentlyViewedProducts()
        {
            var context = httpContextAccessor.HttpContext;
            var cookieKey = "RecentlyViewedProducts";
            var cookieValue = context.Request.Cookies[cookieKey];
            var productIds = string.IsNullOrEmpty(cookieValue) ? new List<Guid>() : cookieValue.Split(',').Select(Guid.Parse).ToList();

            var products = unitOfWork.GetRepository<Product>()
                                     .GetAll()
                                     .Where(p => productIds.Contains(p.Id))
                                     .ToList();

            return products;
        }

    }
}
