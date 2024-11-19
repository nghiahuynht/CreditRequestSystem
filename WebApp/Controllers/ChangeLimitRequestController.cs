using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ChangeLimitRequestController : Controller
    {
        public IActionResult SearchChangLimitRequest()
        {
            return View();
        }


        public IActionResult ChangeLimitRequestDetail()
        {
            return View();
        }


    }
}