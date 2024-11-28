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

        [HttpGet]
        public async Task<JsonResult> DeleteActiveGroup( int Id)
        {
            try
            {
                var rs = await categoryService.DeleteActiveGroup(Id, AuthenInfo().UserName);
                return Json(new
                {
                    success = rs,
                    message = rs == true ? "Xóa thành công." : "Xóa thất bại",
                    projectId = Id
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

        #region DM  mục chi

        public IActionResult MucChi()
        {
            return View();
        }

        [HttpPost]
        // [Authorize(Roles = "Admin")]
        public DataTableResultModel<CategoryExpenseViewModel> GetDataExpense(CategoryFilterModel filter)
        {
            var res = categoryService.GetExpenseByFilter(filter);
            return res;
        }
        public IActionResult _AddMucChi(int id = 0)
        {
            var viewModel = new CategoryExpenseViewModel();

            if (id > 0)
            {
                viewModel = categoryService.GetExpenseById(id);

            }
            else
            {
                viewModel.Id = 0;
            }
            return View(viewModel);


        }


        [HttpPost]
        public async Task<JsonResult> CreateExpense([FromBody] CategoryExpenseViewModel model)
        {
            var res = new SaveResultModel<object>();

            res = await categoryService.CreateExpense(model, User.Identity.Name);
            return Json(res);
        }

        [HttpGet]
        public async Task<JsonResult> DeleteExpense(int Id)
        {
            try
            {
                var rs = await categoryService.DeleteExpense(Id, AuthenInfo().UserName);
                return Json(new
                {
                    success = rs,
                    message = rs == true ? "Xóa thành công." : "Xóa thất bại",
                    projectId = Id
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

        #region DM Thong Tin Thanh Toan
        [HttpGet]
        public IActionResult _AddThongTinThanhToan(int id = 0)
        {
            var viewModel = new PaymentProfileModel();

            if (id > 0)
            {
                var lstHoSoThanhToan = categoryService.GetPaymentProfileByExpense(id);
                var mucChi = categoryService.GetExpenseById(id);
                viewModel.TTHoSoThanhToan = lstHoSoThanhToan;
                viewModel.MucChi = mucChi;

            }
            else
            {
                viewModel.TTHoSoThanhToan = new List<CategoryPaymentProfileViewModel>();
                viewModel.MucChi = new CategoryExpenseViewModel();
            }
            return View(viewModel);


        }

        [HttpPost]
        public async Task<JsonResult> CreatePaymentInfo ([FromBody] CategoryPaymentInfoModel model)
        {
            var res = new SaveResultModel<object>();

            res = await categoryService.CreatePaymentInfo(model, User.Identity.Name);
                return Json(res);
        }

        [HttpGet]
        public JsonResult GetPaymentInfoByExpense(int Id)
        {
            try
            {

                var rs =  categoryService.GetPaymentProfileByExpense(Id);
                return Json(new
                {
                    isSuccess = true,
                    data= rs
                    
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

        [HttpGet]
        public async Task<JsonResult> DeletePaymentProfile(int Id)
        {
            try
            {
                var rs = await categoryService.DeletePaymentProfile(Id, AuthenInfo().UserName);
                return Json(new
                {
                    success = rs,
                    message = rs == true ? "Xóa thành công." : "Xóa thất bại",
                    projectId = Id
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
    }
}