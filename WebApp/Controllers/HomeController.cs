using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DAL.IService;
using DAL.Models.Dashboard;
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
            var lstRes = new List<DashboardColumnChartModel>
            {
                new DashboardColumnChartModel{Thang="T1", TongChi=40000000},
                new DashboardColumnChartModel{Thang="T2", TongChi=55000000},
                 new DashboardColumnChartModel{Thang="T3", TongChi=70500000},
                 new DashboardColumnChartModel{Thang="T4", TongChi=11000000},
                 new DashboardColumnChartModel{Thang="T5", TongChi=9000000},
                new DashboardColumnChartModel{Thang="T6", TongChi=9000000},
                 new DashboardColumnChartModel{Thang="T7", TongChi=12000000},
                  new DashboardColumnChartModel{Thang="T8", TongChi=34000000},
                   new DashboardColumnChartModel{Thang="T9", TongChi=63000000},
                   new DashboardColumnChartModel{Thang="T10", TongChi=77050000},
                   new DashboardColumnChartModel{Thang="T11", TongChi=45250000},
                   new DashboardColumnChartModel{Thang="T12", TongChi=6250000},
            };
            return Json(lstRes);
        }

        [HttpGet]
        public async Task<JsonResult> GetDashBoardCounter(int year)
        {
           
            return Json(true);
        }

    }
}
