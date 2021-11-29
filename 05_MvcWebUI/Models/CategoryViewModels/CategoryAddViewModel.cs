using System;
using System.Collections.Generic;
using _02_Entities.Concrete;

namespace _05_MvcWebUI.Models
{
    public class CategoryAddViewModel
    {
        public Category Category { get; internal set; }
        public int RestaurantId { get; set; }
    }
}
