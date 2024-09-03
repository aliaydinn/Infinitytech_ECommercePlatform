using Microsoft.AspNetCore.Mvc;
using StoreApp.Entity.Entities;
using StoreApp.Service.Services.Abstractions;
using System.Diagnostics;
using X.PagedList;

namespace StoreApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService productService;

        public HomeController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult Index(Filter f)
        {
            var productShowCase = productService.GetAllShowCaseProduct(f).ToPagedList(f.Page,f.PageSize);
            return View(productShowCase);
        }

       


    }
}