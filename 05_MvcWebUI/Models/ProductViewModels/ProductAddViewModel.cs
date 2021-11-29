using System;
using System.Collections.Generic;
using _02_Entities.Concrete;

namespace _05_MvcWebUI.Models
{
    public class ProductAddViewModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; internal set; }
        public Restaurant Restaurant { get; internal set; }
    }

}
