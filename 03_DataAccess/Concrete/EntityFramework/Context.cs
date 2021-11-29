using System;
using _02_Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace _03_DataAccess.Concrete.EntityFramework
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=DESKTOP-M6O799J\SQLEXPRESS;initial catalog=OrderINC;user id=sa;password=sa;multipleactiveresultsets=true;");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }


    }
}
