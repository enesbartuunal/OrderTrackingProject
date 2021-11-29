using System;
using _02_Entities.Concrete;

namespace _05_MvcWebUI.Services
{
    public interface IReceiptSessionService
    {
        Receipt GetReceipt();
        void SetReceipt(Receipt receipt);
    }
}
