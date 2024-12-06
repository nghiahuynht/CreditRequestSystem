using DAL.IService;
using DAL.Models;
using DAL.Models.Permission;
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

        public PermissionController(IProjectFinancialSummarService projectFinancialSummarService,  ICategoryService categoryService, IPermissionService permissionService)
        {
            _projectFinancialSummarService = projectFinancialSummarService;
            _categoryService = categoryService;
            _permissionService = permissionService;
        }
        public IActionResult Index()
        {
            return View();
        }
        #region Phân quyền nv chịu trách nhiệm dự án 
        public async Task<IActionResult> PermisonInChargeIndex()
        {
            PermissionInChargeParModel paramModel = new PermissionInChargeParModel();
            var lstProject = await _projectFinancialSummarService.LstAllProjectFinancialSummar();
            var lstActiveGroup = _categoryService.LstAllCategoryActiveGroup();
            var lstExpense = _categoryService.LstAllCategoryExpense();
            paramModel.LstProject = lstProject;
            paramModel.LstActiveGroup = lstActiveGroup;
            return View(paramModel);
        }

        public DataTableResultModel<PermissionInChargeTableModel> GetDataPermissonInCharge(PermissionInChargeFilterModel filter)
        {
            var res = _permissionService.GetDataPermissionInChargePaging(filter);
            return res;
        }

        [HttpGet]
        public async Task<IActionResult> FormPermissionInCharge(string ProjectName="",int ProjectDetailId = 0, int PermissionInChargeId=0)
        {
            var lstDepartment = _categoryService.LstAllCategoryDepartment();
            ViewBag.PermissionInChargeId = PermissionInChargeId;
            ViewBag.ProjectDetailId = ProjectDetailId;
            ViewBag.ProjectName = ProjectName;
            PermissionInChargeModel model = new PermissionInChargeModel();
            if (PermissionInChargeId == 0)
            {
                model.LstDepartment = lstDepartment;
                model.LstUser = new List<DAL.Models.UserInfo.UserInfoGridModel>();
                model.data = new PermissionInChargeInfoModel();
                model.UserSelected = new DAL.Entities.UserInfo();
                return View(model);
            }
            else
            {
                model.LstDepartment = lstDepartment;
                model.LstUser = new List<DAL.Models.UserInfo.UserInfoGridModel>();
                model.data = new PermissionInChargeInfoModel();
                model.UserSelected = new DAL.Entities.UserInfo();
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
