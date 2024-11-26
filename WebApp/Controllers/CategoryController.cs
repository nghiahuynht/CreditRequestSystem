using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.IService;
using DAL.Models;
using DAL.Models.Category;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class CategoryController : AppBaseController
    {
        private ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }


        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult SaveCategory([FromBody] Category category)
        {
            var res = new SaveResultModel<object>();
            if (category.Id == 0)
            {
                res = categoryService.CreateCategory(category,AuthenInfo().UserName);
            }
            else
            {
                res = categoryService.UpdateCategory(category, AuthenInfo().UserName);
            }
            return Json(res);
        }
        [HttpGet]
        public PartialViewResult _PartialCategorySearch(string keyword)
        {
            var res = categoryService.SearchCategory(keyword);
            return PartialView(res);
        }
        [HttpGet]
        public PartialViewResult _PartialCategoryDetail(int? categoryId)
        {
            var viewModel = new CategoryDetailViewModel();
            if(categoryId.HasValue)
            {
                viewModel.Category = categoryService.GetCategoryById(categoryId.Value);
            }
            else
            {
                viewModel.Category = new Category();
            }
            viewModel.ListParent = categoryService.LstAllCategoies();
            return PartialView(viewModel);
        }


        [HttpPost]
        public JsonResult DeleteCategory(int id)
        {
            var res = categoryService.DeleteCategory(id, AuthenInfo().UserName);
            return Json(res);
        }

        #region DM Nhóm hoạt động

        public IActionResult NhomHoatDong()
        {
            return View();
        }

        [HttpPost]
        // [Authorize(Roles = "Admin")]
        public DataTableResultModel<CategoryActiveGroupViewModel> GetDataActiveGroup(CategoryFilterModel filter)
        {
            var res = categoryService.GetActiveGroupByFilter(filter);
            return res;
        }
        public IActionResult _AddNhomHoatDong(int id = 0)
        {
            var viewModel = new CategoryActiveGroupViewModel();

            if (id > 0)
            {
                viewModel=categoryService.GetActiveGroupById(id);
                
            }
            else
            {
                viewModel.Id = 0;
            }
            return View(viewModel);


        }

        [HttpPost]
        
        public async Task<JsonResult> CreateActiveGroup([FromBody] CategoryActiveGroupViewModel model)
        {
            var res = new SaveResultModel<object>();

            res =await categoryService.CreateActiveGroup(model, User.Identity.Name);
            return Json(res);
        }
        #endregion
    }
}