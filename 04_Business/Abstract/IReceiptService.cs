using System;
using System.Collections.Generic;
using _02_Entities.Concrete;

namespace _04_Business.Abstract
{
    public interface IReceiptService
    {
        void AddToReceipt(Receipt receipt, Product product);

        void RemoveFromReceipt(Receipt receipt, int productId);

        List<ReceiptLine> List(Receipt receipt);
    }
}
