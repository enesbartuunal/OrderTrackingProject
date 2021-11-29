using System;
using _04_Business.Abstract;
using _05_MvcWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace _05_MvcWebUI.ViewComponents
{
    public class AdminCategoryListViewComponent : ViewComponent
    {
        private ICategoryService _categoryService;

        public AdminCategoryListViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ViewViewComponentResult Invoke()
        {
            var model = new CategoryListViewModel()
            {
                Categories = _categoryService.GetAll(),
                CurrentCategory = Convert.ToInt32(HttpContext.Request.Query["category"])
            };

            return View(model);
        }
    }
}
