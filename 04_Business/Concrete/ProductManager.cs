using System;
using System.Collections.Generic;
using _02_Entities.Concrete;
using _03_DataAccess.Abstract;
using _04_Business.Abstract;

namespace _04_Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Delete(int productId)
        {
            _productDal.Delete(new Product { Id = productId });
        }

        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public List<Product> GetByCategory(int categoryId)
        {
            return _productDal.GetList(p => p.CategoryId == categoryId || categoryId == 0);
        }

        public Product GetById(int productId)
        {
            return _productDal.Get(p => p.Id == productId);
        }

        public List<Product> GetByRestaurant(int restaurantId)
        {
            return _productDal.GetList(p => p.RestaurantId == restaurantId);
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }


    }
}
