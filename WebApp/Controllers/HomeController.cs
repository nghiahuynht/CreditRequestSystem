using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DAL.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : AppBaseController
    {
        private IDashboardService dashboardService;
        private IUserInfoService userInfoService;
        public HomeController(IDashboardService dashboardService, IUserInfoService userInfoService)
        {
            this.dashboardService = dashboardService;
            this.userInfoService = userInfoService;
        }
        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
               return RedirectToAction("Login","Account");
            }
            else
            {
                ViewBag.FullNameLogin = AuthenInfo().FullName;


                if (HttpContext.Session.GetString("Permission") == null)// neu da co cookies ma chua co session thi tao lai session
                {
                    string permission = "";
                    var dataPer = await userInfoService.GetPermissionMenuByUserId(AuthenInfo().UserId);
                    foreach (var per in dataPer)
                    {
                        permission += "," + per.Permissions;
                    };
                    HttpContext.Session.SetString("Permission", permission);
                }



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
