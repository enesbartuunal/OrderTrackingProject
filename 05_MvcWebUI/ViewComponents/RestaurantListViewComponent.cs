using System;
using _04_Business.Abstract;
using _05_MvcWebUI.Models.RestaurantViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace _05_MvcWebUI.ViewComponents
{
    public class RestaurantListViewComponent : ViewComponent
    {
        private IRestaurantService _restaurantService;

        public RestaurantListViewComponent(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        public ViewViewComponentResult Invoke()
        {
            var model = new RestaurantListViewModel()
            {
                Restaurants = _restaurantService.GetAll(),
                CurrentRestaurant = Convert.ToInt32(HttpContext.Request.Query["restaurant"])
            };

            return View(model);
        }
    }
}
