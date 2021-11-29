using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using _02_Entities.Concrete;
using _03_DataAccess.Abstract;
using _04_Business.Abstract;

namespace _04_Business.Concrete
{
    public class RestaurantManager : IRestaurantService
    {

        private IRestaurantDal _restaurantDal;

        public RestaurantManager(IRestaurantDal restaurantDal)
        {
            _restaurantDal = restaurantDal;
        }

        public void Add(Restaurant restaurant)
        {
            _restaurantDal.Add(restaurant);
        }

        public void Delete(int restaurantId)
        {
            _restaurantDal.Delete(new Restaurant { Id = restaurantId });
        }

        public List<Restaurant> GetAll()
        {
            return _restaurantDal.GetList();
        }

        public Restaurant GetById(int restaurantId)
        {
            return _restaurantDal.Get(r => r.Id == restaurantId);
        }

        public void Update(Restaurant restaurant)
        {
            _restaurantDal.Update(restaurant);
        }

    }
}
