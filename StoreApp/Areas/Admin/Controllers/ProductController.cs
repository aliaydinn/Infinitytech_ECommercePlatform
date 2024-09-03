using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using StoreApp.Entity.DTOs.ProductsDto;
using StoreApp.Entity.Entities;
using StoreApp.Messages;
using StoreApp.Service.Extensions;
using StoreApp.Service.Services.Abstractions;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly IToastNotification toast;
        private readonly IValidator<Product> validator;
        private readonly IMapper mapper;

        public ProductController(IProductService productService,ICategoryService categoryService,IToastNotification toast,IValidator<Product> validator,IMapper mapper)
        {
            this.productService = productService;
            this.categoryService = categoryService;
            this.toast = toast;
            this.validator = validator;
            this.mapper = mapper;
        }
      
        public IActionResult Index()
        {
            var products = productService.GetAllProduct();
            return View(products);
        }

        //private SelectList GetProductWithCategories()
        //{
        //    var categories = categoryService.GetAllCategory();
        //    return new SelectList(categories, "CategoryId", "Name",Guid.Parse("47b874c1-ea98-401a-9f76-8eb4aa1edee3"));
        //}

        [HttpGet]
        public IActionResult AddProduct()
        {
            var categories = categoryService.GetAllCategory();
            return View(new ProductAddDto { Categories = categories}); ;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductAddDto productAddDto,IFormFile file)
        {      
            var map=mapper.Map<Product>(productAddDto);
            ValidationResult result = validator.Validate(map);
            if (result.IsValid)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);

                using (var stream = new FileStream(path,FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                productAddDto.ImageUrl = string.Concat("/images/", file.FileName);

                var createProductName = productService.ProductAdd(productAddDto);
                toast.AddSuccessToastMessage(NToastMessageProduct.Add(createProductName), new ToastrOptions { Title = "Transaction successful" });
                return RedirectToAction("Index", "Product", new { Area = "Admin" });
            }
            result.AddToModelState(this.ModelState);
            var categories = categoryService.GetAllCategory();
            return View(new ProductAddDto { Categories = categories }); ;

        }

        [HttpGet]
        public IActionResult UpdateProduct(Guid productId)
        {
            var categories = categoryService.GetAllCategory();
            var product=productService.GetByProductDto(productId);
            product.Categories = categories.ToList();
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(ProductUpdateDto productUpdateDto,IFormFile file)
        {
            var map = mapper.Map<Product>(productUpdateDto);
            ValidationResult result=validator.Validate(map);
            if (result.IsValid)
            {
                if (file is not null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    productUpdateDto.ImageUrl = string.Concat("/images/", file.FileName);
                    var updateProductName = productService.ProductUpdate(productUpdateDto);
                    toast.AddInfoToastMessage(NToastMessageProduct.Update(updateProductName), new ToastrOptions { Title = "Transaction successful" });
                    return RedirectToAction("Index", "Product", new { Area = "Admin" });
                }
                else
                {
                    var updateProductName = productService.ProductUpdate(productUpdateDto);
                    toast.AddInfoToastMessage(NToastMessageProduct.Update(updateProductName), new ToastrOptions { Title = "Transaction successful" });
                    return RedirectToAction("Index", "Product", new { Area = "Admin" });
                }
              

            }
            result.AddToModelState(this.ModelState);
            var categories = categoryService.GetAllCategory();
            var productImageUrl = productService.GetByProduct(productUpdateDto.Id);
            return View(new ProductUpdateDto { Categories = categories.ToList(),ImageUrl=productImageUrl.ImageUrl });
           
        }
        [HttpGet]
        public IActionResult DeleteProduct(Guid Id)
        {
            var deleteProductName=productService.ProductDelete(Id);
            toast.AddErrorToastMessage(NToastMessageProduct.Delete(deleteProductName), new ToastrOptions { Title = "Transaction successful" });
            return RedirectToAction("Index", "Product", new { Area = "Admin" });
        }
    }
}
