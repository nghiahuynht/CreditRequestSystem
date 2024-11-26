using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class PaymentRequestController : Controller
    {
        public IActionResult SearchRequest()
        {
            return View();
        }

        public IActionResult RequestDetail()
        {
            return View();
        }




    }
}