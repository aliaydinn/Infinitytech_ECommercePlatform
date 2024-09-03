using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApp.Service.Services.Abstractions;

namespace StoreApp.ViewComponents
{
    public class ProductWithCategoriesViewComponent : ViewComponent
    {
        private readonly ICategoryService categoryService;

        public ProductWithCategoriesViewComponent(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = categoryService.GetAllCategory().Include(x => x.Products); 
            return View(categories);
        }
    }
}
