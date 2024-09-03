using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using StoreApp.Entity.DTOs.CategoriesDto;
using StoreApp.Messages;
using StoreApp.Service.Services.Abstractions;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {

        private readonly ICategoryService categoryService;
        private readonly IToastNotification toast;

        public CategoryController(ICategoryService categoryService, IToastNotification toast)
        {
            this.categoryService = categoryService;
            this.toast = toast;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var categories = categoryService.GetAllCategory();
            return View(categories);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryAddDto categoryAddDto,IFormFile file)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images",file.FileName);
            using (var stream=new FileStream(path,FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            categoryAddDto.ImageUrl=string.Concat("/images/",file.FileName);
            var createCategoryName = categoryService.CategoryAdd(categoryAddDto);
            toast.AddSuccessToastMessage(NToastMessageCategory.Add(createCategoryName), new ToastrOptions { Title = "Transaction successful" });
            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }

        [HttpGet]
        public IActionResult UpdateCategory( Guid Id)
        {
            var category=categoryService.GetCategory(Id);
            return View(category);
        }

        [HttpPost]
        public IActionResult UpdateCategory(CategoryUpdateDto categoryUpdateDto)
        {
            var categoryUpdateName=categoryService.CategoryUpdate(categoryUpdateDto);
            toast.AddInfoToastMessage(NToastMessageCategory.Update(categoryUpdateName), new ToastrOptions { Title = "Transaction successful" });
            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }

        [HttpGet]
        public IActionResult DeleteCategory(Guid categoryId)
        {
            var categoryDeletedName=categoryService.CategorySafeDelete(categoryId);
            toast.AddErrorToastMessage(NToastMessageCategory.Delete(categoryDeletedName), new ToastrOptions { Title = "Transaction successful" });
            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }
    }
}
