using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Data.Context;
using StoreApp.Entity.DTOs.ProductsDto;
using StoreApp.Entity.Entities;
using StoreApp.Service.Services.Abstractions;
using StoreApp.Service.Services.Concretions;
using X.PagedList;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;

        public ProductController(IProductService productService,IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }
        public IActionResult Index(Filter f)
        {
            var products = productService.GetAllProductFilter(f).ToPagedList(f.Page,f.PageSize);
            var filterProductCount=products.Count();
            ViewBag.ProductCount = filterProductCount;
            return View(products);
            
        }

        public IActionResult GetProductDetail(Guid productId)
        {
            var product = productService.GetByProduct(productId);
            if (product != null)
            {
                productService.AddToRecentlyViewed(productId); // Ürünü görüntülemede ekle
               
            }
            var map = mapper.Map<ProductDto>(product);
            return View(map);
        }
    }
}
