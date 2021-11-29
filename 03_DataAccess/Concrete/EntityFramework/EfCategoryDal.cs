using System;
using _01_AppCore.DataAccess.EntityFramework;
using _02_Entities.Concrete;
using _03_DataAccess.Abstract;

namespace _03_DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, Context>, ICategoryDal
    {

    }
}
