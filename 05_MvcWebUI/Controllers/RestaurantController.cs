using System;
using _04_Business.Abstract;
using _05_MvcWebUI.Models.RestaurantViewModels;
using Microsoft.AspNetCore.Mvc;

namespace _05_MvcWebUI.Controllers
{
    public class RestaurantController : Controller
    {
        private IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        public IActionResult Index()
        {
            var restaurantListViewModel = new RestaurantListViewModel()
            {
                Restaurants = _restaurantService.GetAll()
            };
            return View(restaurantListViewModel);
        }
    }
}