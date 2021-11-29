using System;
using System.Collections.Generic;
using _02_Entities.Concrete;

namespace _04_Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();

        List<Product> GetByCategory(int categoryId);

        List<Product> GetByRestaurant(int restaurantId);

        void Add(Product product);

        void Update(Product product);

        void Delete(int productId);

        Product GetById(int productId);
    }
}
