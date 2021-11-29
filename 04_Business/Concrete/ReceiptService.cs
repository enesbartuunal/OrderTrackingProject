using System;
using System.Collections.Generic;
using System.Linq;
using _02_Entities.Concrete;
using _04_Business.Abstract;

namespace _04_Business.Concrete
{
    public class ReceiptService : IReceiptService
    {
        public void AddToReceipt(Receipt receipt, Product product)
        {
            ReceiptLine receiptLine = receipt.ReceiptLines.FirstOrDefault(r => r.Product.Id == product.Id);
            if (receiptLine != null)
            {
                receiptLine.Quantity++;
                return;
            }
            receipt.ReceiptLines.Add(new ReceiptLine { Product = product, Quantity = 1 });
        }

        public List<ReceiptLine> List(Receipt receipt)
        {
            return receipt.ReceiptLines;
        }

        public void RemoveFromReceipt(Receipt receipt, int productId)
        {
            receipt.ReceiptLines.Remove(receipt.ReceiptLines.FirstOrDefault(r => r.Product.Id == productId));
        }
    }
}
