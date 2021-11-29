using System;
using System.Collections.Generic;
using _02_Entities.Concrete;

namespace _05_MvcWebUI.Models
{
    public class ProductListViewModel
    {
        public List<Product> Products { get; internal set; }
        public int PageCount { get; internal set; }
        public int PageSize { get; internal set; }
        public int CurrentPage { get; internal set; }
        public int CurrentCategory { get; internal set; }
        public Restaurant Restaurant { get; internal set; }
        
    }
}
