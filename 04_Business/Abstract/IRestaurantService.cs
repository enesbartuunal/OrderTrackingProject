using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using _01_AppCore.Entities;
using _02_Entities.Concrete;

namespace _04_Business.Abstract
{
    public interface IRestaurantService
    {
        List<Restaurant> GetAll();

        void Add(Restaurant restaurant);

        void Update(Restaurant restaurant);

        void Delete(int restaurantId);

        Restaurant GetById(int restaurantId);
    }
}
