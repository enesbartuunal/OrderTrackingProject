using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using _02_Entities.Concrete;
using _03_DataAccess.Abstract;
using _04_Business.Abstract;

namespace _04_Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void Add(Category category)
        {
            _categoryDal.Add(category);
        }

        public void Delete(int categoryId)
        {
            _categoryDal.Delete(new Category { Id = categoryId });
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetList();
        }

        public Category GetById(int categoryId)
        {
            return _categoryDal.Get(c => c.Id == categoryId);
        }

        public List<Category> GetByRestaurant(int restaurantId)
        {
            return _categoryDal.GetList(c => c.RestaurantId == restaurantId);
        }

        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }
    }
}
