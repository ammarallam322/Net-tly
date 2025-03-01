using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using teamProject.Models;
using teamProject.Services;
using teamProject.viewModel;

namespace teamProject.Controllers
{
    public class PaymentViewModelsController : Controller  //PaymentViewModels
    {

        public PaymentViewModelsController(IPaymentSevice PaymentSevice)
        {
            this.PaymentSevice = PaymentSevice;
        }

        IPaymentSevice PaymentSevice { get; set; }
        public async Task<IActionResult> Index()
        {
            return View("Index", await PaymentSevice.GetAll());
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var paymentViewModel = await PaymentSevice.GetById(id); // استخدم await هنا للحصول على النتيجة الفعلية.
            if (paymentViewModel == null)
            {
                return NotFound();
            }

            return View(paymentViewModel);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PaymentViewModel paymentVM)
        {
            if (paymentVM == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View("Index", paymentVM);
            }

            bool isPaymentProcessed =await  PaymentSevice.ProcessPayment(paymentVM);

            return isPaymentProcessed ? RedirectToAction("Success") : View("Index", paymentVM);
        }

        public IActionResult Success()
        {
            ViewData["SuccessMessage"] = "Your payment has been processed successfully!";
            return View();
        }
    }
}
