using System;
using System.Collections.Generic;
using _02_Entities.Concrete;

namespace _05_MvcWebUI.Models.RestaurantViewModels
{
    public class RestaurantListViewModel
    {
        public RestaurantListViewModel()
        {
        }

        public List<Restaurant> Restaurants { get; internal set; }

        public int PageCount { get; internal set; }
        public int PageSize { get; internal set; }
        public int CurrentPage { get; internal set; }
        public int CurrentCategory { get; internal set; }
        public int CurrentRestaurant { get; internal set; }
    }
}
