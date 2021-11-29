using System;
using System.Collections.Generic;
using _02_Entities.Concrete;

namespace _05_MvcWebUI.Models
{
    public class CategoryListViewModel
    {
        public List<Category> Categories { get; internal set; }
        public int CurrentCategory { get; internal set; }
        //public List<Restaurant> Restaurants { get; internal set; }
        public int RestaurantId { get;internal set; }

    }
}