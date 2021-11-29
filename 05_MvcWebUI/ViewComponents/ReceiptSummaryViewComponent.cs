using System;
using _05_MvcWebUI.Models;
using _05_MvcWebUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace _05_MvcWebUI.ViewComponents
{
    public class ReceiptSummaryViewComponent : ViewComponent
    {
        private IReceiptSessionService _receiptSessionService;

        public ReceiptSummaryViewComponent(IReceiptSessionService receiptSessionService)
        {
            _receiptSessionService = receiptSessionService;
        }

        public ViewViewComponentResult Invoke()
        {
            var model = new ReceiptSummaryViewModel
            {
                Receipt = _receiptSessionService.GetReceipt()
            };
            return View(model);
        }
    }
}
