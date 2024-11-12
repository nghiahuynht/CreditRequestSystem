using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DAL.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : AppBaseController
    {
        private IDashboardService dashboardService;
        public HomeController(IDashboardService dashboardService)
        {
            this.dashboardService = dashboardService;
        }
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
               return RedirectToAction("Login","Account");
            }
            else
            {
                ViewBag.FullNameLogin = AuthenInfo().FullName;
                return View();
            }
           
        }
        [Authorize(Roles ="Admin")]
        public IActionResult Privacy()
        {
            var test = User.Identity.Name;
            return View();
        }
        [Authorize(Roles = "Sale")]
        public IActionResult Contact()
        {

            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetDashBoardColumnChart(int year)
        {
           
            return Json(true);
        }

        [HttpGet]
        public async Task<JsonResult> GetDashBoardCounter(int year)
        {
           
            return Json(true);
        }

    }
}
