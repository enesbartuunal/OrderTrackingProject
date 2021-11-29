using System;
using _04_Business.Abstract;
using _05_MvcWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace _05_MvcWebUI.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        private ICategoryService _categoryService;

        public CategoryListViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ViewViewComponentResult Invoke(int restaurantId)
        {
            var model = new CategoryListViewModel()
            {
                Categories = _categoryService.GetByRestaurant(restaurantId),
                CurrentCategory = Convert.ToInt32(HttpContext.Request.Query["category"])
            };

            return View(model);
        }
    }
}
