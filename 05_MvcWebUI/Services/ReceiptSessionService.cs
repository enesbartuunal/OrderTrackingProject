using System;
using _02_Entities.Concrete;
using _05_MvcWebUI.ExtensionMethods;
using Microsoft.AspNetCore.Http;

namespace _05_MvcWebUI.Services
{
    public class ReceiptSessionService : IReceiptSessionService
    {

        private IHttpContextAccessor _httpContextAccessor;

        public ReceiptSessionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Receipt GetReceipt()
        {
            Receipt receiptToCheck = _httpContextAccessor.HttpContext.Session.GetObject<Receipt>("receipt");
            if (receiptToCheck == null)
            {
                _httpContextAccessor.HttpContext.Session.SetObject("receipt", new Receipt());
                receiptToCheck = _httpContextAccessor.HttpContext.Session.GetObject<Receipt>("receipt");
            }
            return receiptToCheck;
        }

        public void SetReceipt(Receipt receipt)
        {
            _httpContextAccessor.HttpContext.Session.SetObject("receipt", receipt);
        }
    }
}
