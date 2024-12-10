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
            return View(par);
        }

        public DataTableResultModel<PermissionInChargeTableModel> GetDataPermissonInCharge(PermissionInChargeFilterModel filter)
        {
            var res = _permissionService.GetDataPermissionInChargePaging(filter);
            return res;
        }

        [HttpGet]
        public async Task<IActionResult> FormPermissionInCharge(int id=0,string fullName = "")
        {
            var lstDepartment = _categoryService.LstAllCategoryDepartment();

            PermissionInChargeModel model = new PermissionInChargeModel();
            var lstProject = await _projectFinancialSummarService.LstAllProjectFinancialSummar();
            var dm_NhomHoatDong = _categoryService.LstAllCategoryActiveGroup();
            if (id == 0)
            {
                model.LstProject = lstProject;
                model.DM_NhomHoatDong = dm_NhomHoatDong;
                model.data = new PermissionInChargeInfoModel();
                return View(model);
            }
            else
            {
                model.LstProject = lstProject;
                model.DM_NhomHoatDong = dm_NhomHoatDong;
                model.data = new PermissionInChargeInfoModel();
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
        #endregion
    }
}
