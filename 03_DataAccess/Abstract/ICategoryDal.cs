using System;
using _01_AppCore.DataAccess;
using _02_Entities.Concrete;

namespace _03_DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
    }
}
