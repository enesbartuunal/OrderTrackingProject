using System;
using System.Linq;
using _02_Entities.Concrete;
using _04_Business.Abstract;
using _05_MvcWebUI.Models;
using _05_MvcWebUI.Models.RestaurantViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

namespace _05_MvcWebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        private IRestaurantService _restaurantService;

        public AdminController(IProductService productService, ICategoryService categoryService, IRestaurantService restaurantService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _restaurantService = restaurantService;
        }

        public ActionResult Index(int restaurantId, int page = 1)
        {
            int pageSize = 10;
            var products = _productService.GetByRestaurant(restaurantId);
            var productListViewModel = new ProductListViewModel()
            {
                Products = products.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                PageCount = Convert.ToInt32(Math.Ceiling(products.Count / (double)pageSize)),
                PageSize = pageSize,
                CurrentPage = page,
                Restaurant = _restaurantService.GetById(restaurantId)
            };
            return View(productListViewModel);
        }

        public ActionResult Add(int restaurantId)
        {
            var model = new ProductAddViewModel()
            {
                Product = new Product()
                {
                    RestaurantId = restaurantId
                },
                Restaurant = _restaurantService.GetAll().FirstOrDefault(r => r.Id == restaurantId),
                Categories = _categoryService.GetByRestaurant(restaurantId)
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Add(product);
                TempData.Add("message", "Product was successfully added.");

            }
            return RedirectToAction("Index", "Admin", new { restaurantId = product.RestaurantId });
        }


        public ActionResult AddCategory(int restaurantId)
        {
            var model = new CategoryAddViewModel()
            {
                Category = new Category(),

                RestaurantId = restaurantId
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult AddCategory(Category category, int RestaurantId)
        {
            try
            {
                category.RestaurantId = RestaurantId;
                _categoryService.Add(category);
                TempData.Add("message", "Category was successfully added.");
                return RedirectToAction("Categories", "Admin", new { restaurantId = RestaurantId });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult Update(int productId)
        {
            var model = new ProductUpdateViewModel()
            {
                Product = _productService.GetById(productId)
            };
            return View(model);
        }


        [HttpPost]
        public ActionResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Update(product);
                TempData.Add("message", "Product was successfully updated.");
            }
            return RedirectToAction("Index","Admin",new {restaurantId= product.RestaurantId });
        }

        public ActionResult Delete(int productId)
        {
            _productService.Delete(productId);
            TempData.Add("message", "Product was successfully deleted.");
            return Redirect(HttpContext.Request.Headers["Referer"]);
        }

        public ActionResult DeleteCategory(int categoryId)
        {
            _categoryService.Delete(categoryId);
            TempData.Add("message", "Cateogry was successfully deleted.");
            return Redirect(HttpContext.Request.Headers["Referer"]);
        }

        public ActionResult Categories(int restaurantId)
        {
            var categoryListViewModel = new CategoryListViewModel
            {
                Categories = _categoryService.GetByRestaurant(restaurantId),
                RestaurantId = restaurantId
            };


            return View(categoryListViewModel);
        }

        public ActionResult Restaurants()
        {
            try
            {
                var restaurantListViewModel = new RestaurantListViewModel
                {
                    Restaurants = _restaurantService.GetAll()
                };
                return View(restaurantListViewModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult AddRestaurant()
        {
            var model = new RestaurantAddViewModel()
            {
                Restaurant = new Restaurant()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult AddRestaurant(Restaurant restaurant)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _restaurantService.Add(restaurant);
                    TempData.Add("message", "Restaurant was successfully added.");
                }
                return RedirectToAction("Restaurants", "Admin");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult DeleteRestaurant(int restaurantId)
        {
            _restaurantService.Delete(restaurantId);
            TempData.Add("message", "Restaurant was successfully deleted.");
            return RedirectToAction("Restaurants", "Admin");
        }
    }
}
