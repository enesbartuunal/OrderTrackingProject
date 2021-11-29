using System;
using _02_Entities.Concrete;
using _04_Business.Abstract;
using _05_MvcWebUI.Models;
using _05_MvcWebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace _05_MvcWebUI.Controllers
{
    public class ReceiptController : Controller
    {
        private IReceiptSessionService _receiptSessionService;

        private IReceiptService _receiptService;

        private IProductService _productService;

        public ReceiptController(IReceiptSessionService receiptSessionService, IReceiptService receiptService, IProductService productService)
        {
            _receiptService = receiptService;
            _receiptSessionService = receiptSessionService;
            _productService = productService;
        }

        public IActionResult AddToReceipt(int productId)
        {
            var productToAdded = _productService.GetById(productId);

            var receipt = _receiptSessionService.GetReceipt();

            _receiptService.AddToReceipt(receipt, productToAdded);

            _receiptSessionService.SetReceipt(receipt);

            TempData.Add("message", String.Format("Meal {0} is added to receipt.", productToAdded.Name));

            return Redirect(HttpContext.Request.Headers["Referer"]);
        }

        public ActionResult List()
        {
            var receipt = _receiptSessionService.GetReceipt();
            ReceiptListViewModel receiptListViewModel = new ReceiptListViewModel()
            {
                Receipt = receipt
            };
            return View(receiptListViewModel);
        }

        public ActionResult ContinueOrdering()
        {
            return Redirect(HttpContext.Request.Headers["Referer"]);
        }

        public ActionResult Remove(int productId)
        {
            var receipt = _receiptSessionService.GetReceipt();
            _receiptService.RemoveFromReceipt(receipt, productId);
            _receiptSessionService.SetReceipt(receipt);
            TempData.Add("message", String.Format("Your meal is removed from the receipt!"));
            return RedirectToAction("List");
        }

        public ActionResult Complete()
        {
            var shippingDetailsViewModel = new ShippingDetailsViewModel()
            {
                ShippingDetails = new ShippingDetails()
            };
            return View();
        }

        [HttpPost]
        public ActionResult Complete(ShippingDetails shippingDetails)
        {
            if (!ModelState.IsValid)
            {
                                return View();
            }
            
            TempData.Add("message", String.Format("Thank you {0}, your order is in proccess.", shippingDetails.FirstName));
            return RedirectToAction("Index","Restaurant");
        }
    }
}
