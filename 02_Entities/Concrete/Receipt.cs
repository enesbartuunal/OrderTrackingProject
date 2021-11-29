using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_Entities.Concrete
{
    public class Receipt
    {
        public Receipt()
        {
            ReceiptLines = new List<ReceiptLine>();
        }
        public List<ReceiptLine> ReceiptLines { get; set; }

        public decimal TotalPrice
        {
            get { return (decimal)ReceiptLines.Sum(r => r.Product.Price * r.Quantity); }
        }
    }
}
