using System;
using System.Collections.Generic;
using _01_AppCore.Entities;

namespace _02_Entities.Concrete
{
    public class Category : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Product> Product { get; set; }

        public int RestaurantId { get; set; }

    }
}
