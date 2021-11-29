using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using _02_Entities.Concrete;

namespace _04_Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();

        List<Category> GetByRestaurant(int restaurantId);

        Category GetById(int categoryId);

        void Add(Category category);

        void Update(Category category);

        void Delete(int categoryId);
    }
}
