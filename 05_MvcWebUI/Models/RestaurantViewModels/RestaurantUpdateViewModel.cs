using System;
using _02_Entities.Concrete;

namespace _05_MvcWebUI.Models.RestaurantViewModels
{
    public class RestaurantUpdateViewModel
    {
        public RestaurantUpdateViewModel()
        {
        }

        public Restaurant Restaurant { get; internal set; }
    }
}
