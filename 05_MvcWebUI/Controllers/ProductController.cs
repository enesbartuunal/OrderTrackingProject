using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _04_Business.Abstract;
using _05_MvcWebUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _05_MvcWebUI.Controllers
{
    public class ProductController : Controller
    {

        private IProductService _productService;
        private ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        // GET: Product
        public ActionResult Index(int restaurantId, int page = 1, int category = 0)
        {
            int pageSize = 10;
            var products = _productService.GetByRestaurant(restaurantId);
            var categorysssss = _categoryService.GetByRestaurant(restaurantId);
            ProductListViewModel model = new ProductListViewModel
            {
                Products = products.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                PageCount = Convert.ToInt32(Math.Ceiling(products.Count / (double)pageSize)),
                PageSize = pageSize,
                CurrentPage = page,

            };
            
            model.CurrentCategory = Convert.ToInt32(HttpContext.Request.Query["category"]);
            var a = 0;
           
            TempData["restaurantId"] = restaurantId;
            return View(model);
        }
    }
}