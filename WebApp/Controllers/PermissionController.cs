using DAL.IService;
using DAL.Models;
using DAL.Models.Permission;
using DAL.Models.UserInfo;
using DAL.Service;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebApp.Controllers
{
    public class PermissionController : Controller
    {
        private IProjectFinancialSummarService _projectFinancialSummarService;
        private ICategoryService _categoryService;
        private IPermissionService _permissionService;
        private IUserInfoService _userService;

        public PermissionController(IProjectFinancialSummarService projectFinancialSummarService,  ICategoryService categoryService, IPermissionService permissionService, IUserInfoService userService)
        {
            _projectFinancialSummarService = projectFinancialSummarService;
            _categoryService = categoryService;
            _permissionService = permissionService;
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }
        #region Phân quyền nv chịu trách nhiệm dự án 
        public async Task<IActionResult> PermisonInChargeIndex()
        {
            UserParViewModel par = new UserParViewModel();
            var lstRoles = _userService.GetAllRoles();
            var lstDepartment = _categoryService.LstAllCategoryDepartment();
            par.LstRoles = lstRoles;
            par.LstDepartment = lstDepartment;
            ViewBag.Permissions = HttpContext.Session.GetString("Permission");

            return View(par);
        }

       

        [HttpGet]
        public async Task<IActionResult> FormPermissionInCharge(int id=0,string fullName = "")
        {

            PermissionInChargeModel model = new PermissionInChargeModel();
            var lstProject = await _projectFinancialSummarService.LstAllProjectFinancialSummar();
           
            ViewBag.UserId = id;
            ViewBag.UserName = fullName;
            if (id == 0)
            {
                model.LstProject = lstProject;
                model.data = new PermissionInChargeInfoModel();
                return View(model);
            }
            else
            {
                var lstPermission= await _permissionService.GetPermissionProjectByUserId(id);
                // remove project đã được phân quyền
                lstProject = lstProject.FindAll(x => lstPermission.FindIndex(t => t.ProjectId == x.Id) ==-1);
                model.LstProject = lstProject;
                model.data = new PermissionInChargeInfoModel();            
                model.lstPermissionProject = lstPermission;
                return View(model);
            }


        }


        [HttpPost]
        public async Task<JsonResult> CreatePermissionInCharge([FromBody] PermissionInChargeCreateModel model)
        {
            var res = new SaveResultModel<object>();

            res = await _permissionService.CreatePermissionInCharge(model, User.Identity.Name);
            return Json(res);
        }

        [HttpGet]
        public async Task<JsonResult> DeletePermissionProjectById(int Id)
        {
            try
            {
                var user = await _permissionService.DeletePermissionProjectById(Id);

                return Json(new
                {
                    success = true,
                    message = "Thành công"
                });
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về thông báo lỗi
                return Json(new
                {
                    success = false,
                    message = $"Đã xảy ra lỗi: {ex.Message}"
                });
            }
        }


        #endregion
        #region Phân quyên nv yc hoàn tiền
        [HttpGet]
        public async Task<IActionResult> PermisonCreateRequest()
        {
            UserParViewModel par = new UserParViewModel();
            var lstRoles = _userService.GetAllRoles();
            var lstDepartment = _categoryService.LstAllCategoryDepartment();
            par.LstRoles = lstRoles;
            par.LstDepartment = lstDepartment;
            ViewBag.Permissions = HttpContext.Session.GetString("Permission");
            return View(par);
        }

        [HttpGet]
        public async Task<IActionResult> FormPermissionCreateRequest(int id = 0, string fullName = "")
        {


            PermissionCreateRequestModel model = new PermissionCreateRequestModel();
            var lstProject = await _projectFinancialSummarService.LstAllProjectAllocation();
            var dm_NhomHoatDong = _categoryService.LstAllCategoryActiveGroup();
            ViewBag.UserId = id;
            ViewBag.UserName = fullName;
            if (id == 0)
            {
                model.LstProject = lstProject;
                model.DM_NhomHoatDong = dm_NhomHoatDong;
                model.data = new PermissionCreateRequestInfoModel();
                return View(model);
            }
            else
            {
                var lstPermission = await _permissionService.GetPermissionCreateRequestByUserId(id);
                model.LstProject = lstProject;
                model.DM_NhomHoatDong = dm_NhomHoatDong;
                model.data = new PermissionCreateRequestInfoModel();
                model.lstPermissionProject = lstPermission;
                return View(model);
            }


        }

        [HttpPost]
        public async Task<JsonResult> CreatePermissionCreateRequest([FromBody] CreatePermissionCreateRequestModel model)
        {
            var res = new SaveResultModel<object>();

            res = await _permissionService.CreatePermissionCreateRequest(model, User.Identity.Name);
            return Json(res);
        }
        #endregion
    }
}
