using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using _01_AppCore.Entities;

namespace _02_Entities.Concrete
{
    public class Product : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int CategoryId { get; set; }

        public int RestaurantId { get; set; }
    }
}
