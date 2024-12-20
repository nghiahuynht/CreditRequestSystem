using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.IService;
using DAL.Models;
using DAL.Models.Category;
using DAL.Models.ProjectFinancialSummar;
using DAL.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

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
            if(res.LongValReturn == -409)
            {
                res.IsSuccess = false;
                res.ErrorMessage = "Mã nhóm hoạt động đã tồn tại!";

            }    
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
                    message = rs == true ? "Xóa thành công." : "Xóa thất bại.Đã phát sinh hồ sơ thanh toán",
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


        [HttpGet]
        public JsonResult GetActiveGroupAllocationByProductId(int Id)
        {
            try
            {

                var rs = categoryService.LstCategoryActiveGroupAllocationByProductId(Id);
                return Json(new
                {
                    isSuccess = true,
                    data = rs

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


        [HttpPost]
        public IActionResult ReadFileImportActiveGroup(IFormFile file)
        {
            // Get all DM Trung Tam
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            List<CategoryActiveGroupViewModel> lstProject = new List<CategoryActiveGroupViewModel>();
            if (file == null || file.Length == 0)
                return BadRequest("File không hợp lệ");
            string[] permittedExtensions = { ".xlsx", ".xls" };
            var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
            {
                return BadRequest("File không hợp lệ");
            }
            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);

                using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                    int rows = worksheet.Dimension.Rows;
                    int columns = worksheet.Dimension.Columns;
                    // Check number rows
                    if (rows > 201)
                    {
                        return BadRequest("File vượt quá số dòng tối đa (200 dòng)");
                    }
                    int indexHaveData = 1;
                    for (int row = 2; row <= rows; row++)
                    {

                        if (columns > 0 && row > 1)
                        {
                            object tenNhomHoatDong = worksheet.Cells[row, 1].Value;

                            


                            if (string.IsNullOrEmpty(tenNhomHoatDong?.ToString()))
                            {
                                return BadRequest("Tên nhóm hoạt động không được bỏ trống");
                            }



                            CategoryActiveGroupViewModel item = new CategoryActiveGroupViewModel
                            {

                               Code = "",
                               Name = tenNhomHoatDong.ToString()

                            };
                            lstProject.Add(item);
                        }
                    }
                }
            }
            return Json(new
            {
                data = lstProject,
                Status = "Success"
            });

        }

        [HttpPost]
        public async Task<IActionResult> ImportActiveGroup([FromBody] List<CategoryActiveGroupViewModel> data)
        {

            try
            {
                List<ResImportActiveGroupModel> resImport = new List<ResImportActiveGroupModel>();
                foreach (var item in data)
                {
                    var res = await categoryService.CreateActiveGroup(item, AuthenInfo().UserName);
                    string ms = "Thành công";
                    if (res.LongValReturn < 0)
                    {
                        if (res.LongValReturn == -409)
                        {
                            ms = "Mã dự án đã tồn tại";
                        }
                        else
                        {
                            ms = "Thất bại";

                        }
                    };

                    resImport.Add(new ResImportActiveGroupModel()
                    {
                        item = item,
                        message = ms
                    });
                }
                return Json(new
                {
                    data = resImport,
                    Status = "Thành công"

                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    message = ex.Message,
                    Status = "Thất bại",

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
        public DataTableResultModel<CategoryExpenseTableViewModel> GetDataExpense(CategoryFilterModel filter)
        {
            var res = categoryService.GetExpenseByFilter(filter);
            return res;
        }
        public IActionResult _AddMucChi(int id = 0)
        {
            var viewModel = new CategoryExpenseViewModel();
            var lstNhomHoatDong = categoryService.LstAllCategoryActiveGroup();
            if (id > 0)
            {
                viewModel = categoryService.GetExpenseById(id);

            }
            else
            {
                viewModel.Id = 0;
            }
            ViewBag.LstActiveGroup = lstNhomHoatDong;
            return View(viewModel);


        }


        [HttpPost]
        public async Task<JsonResult> CreateExpense([FromBody] CategoryExpenseViewModel model)
        {
            var res = new SaveResultModel<object>();

            res = await categoryService.CreateExpense(model, User.Identity.Name);
            if (res.LongValReturn == -409)
            {
                res.IsSuccess = false;
                res.ErrorMessage = "Mã mục chi đã tồn tại!";

            }
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

        public JsonResult GetExpenseByActiveGroup(int Id)
        {

            try
            {
                var rs = categoryService.GetExpenseByActiveGroup(Id);
                return Json(new
                {
                    isSuccess = true,
                    data = rs

                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    isSuccess = false,
                    message = ex.Message

                });
            }
            
        }

        #endregion

        #region DM Thong Tin Thanh Toan

        public IActionResult ThongTinHoSoThanhToan()
        {
            return View();
        }

        [HttpPost]
        // [Authorize(Roles = "Admin")]
        public DataTableResultModel<CategoryPaymentProfileViewModel> GetDataPaymentProfile(CategoryFilterModel filter)
        {
            var res = categoryService.GetPaymentProfileByFilter(filter);
            return res;
        }

        public IActionResult _AddThongTinHoSoThanhToan(int id = 0)
        {
            var viewModel = new CategoryPaymentProfileAddViewModel();
            if (id > 0)
            {
                viewModel.data = categoryService.GetPaymentProfileById(id);
                viewModel.detail = categoryService.GetPaymentProfileDetailByPaymentProfileId(id);

            }
            else
            {
                viewModel.data= new CategoryPaymentProfileViewModel();
                viewModel.detail= new List<CategoryPaymentProfileDetailViewModel>();
                viewModel.data.Id = 0;
            }

            return View(viewModel);


        }

        [HttpGet]
        public IActionResult _AddThongTinThanhToanMucChi(int id = 0)
        {
            var viewModel = new PaymentProfileModel();

            if (id > 0)
            {
                var lstHoSoThanhToan = categoryService.GetPaymentProfileByExpense(id);
                var mucChi = categoryService.GetExpenseById(id);
                viewModel.TTHoSoThanhToan = lstHoSoThanhToan;
                viewModel.MucChi = mucChi;
                viewModel.LstPaymentProfile = categoryService.LstAllCategoryPaymentProfile();
            }
            else
            {
                viewModel.TTHoSoThanhToan = new List<CategoryPaymentProfileViewModel>();
                viewModel.MucChi = new CategoryExpenseViewModel();
                viewModel.LstPaymentProfile = categoryService.LstAllCategoryPaymentProfile();
            }
            return View(viewModel);


        }

        [HttpPost]
        public async Task<JsonResult> CreatePaymentInfo ([FromBody] CategoryPaymentInfoModel model)
        {
            var res = new SaveResultModel<object>();

            res = await categoryService.CreatePaymentProfile(model, User.Identity.Name);

            if (res.LongValReturn == -409)
            {
                res.IsSuccess = false;
                res.ErrorMessage = "Mã hồ sơ đã tồn tại!";

            }
            else
            {
                // save table detail
                foreach(var dt in model.detail)
                {
                    dt.PaymentProfileId = (int)res.LongValReturn;
                   var resDetail = await categoryService.CreatePaymentProfileDetail(dt, User.Identity.Name);
                }    
            }    
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


        [HttpGet]
        public async Task<JsonResult> DeletePaymentProfileDetail(int Id)
        {
            try
            {
                var rs = await categoryService.DeletePaymentProfileDetail(Id);
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

        [HttpPost]
        public async Task<JsonResult> CreateExpensePaymentInfo([FromBody] ExpensePaymentInfoModel model)
        {
            var res = new SaveResultModel<object>();

            res = await categoryService.CreateExpensePaymentInfo(model, User.Identity.Name);

            if (res.LongValReturn == -409)
            {
                res.IsSuccess = false;
                res.ErrorMessage = "Mã hồ sơ đã tồn tại!";

            }
            
            
            return Json(res);
        }

        [HttpGet]
        public async Task<JsonResult> DeleteExpensePaymentProfile(int Id)
        {
            try
            {
                var rs = await categoryService.DeleteExpensePaymentProfile(Id);
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

        #region DM Bo Phan
        public IActionResult BoPhan()
        {
            return View();
        }

        [HttpPost]
        // [Authorize(Roles = "Admin")]
        public DataTableResultModel<CategoryDepartmentViewModel> GetDataDepartment(CategoryFilterModel filter)
        {
            var res = categoryService.GetDepartmentByFilter(filter);
            return res;
        }

        public IActionResult _AddBoPhan(int id = 0)
        {
            var viewModel = new CategoryDepartmentViewModel();
            if (id > 0)
            {
                viewModel = categoryService.GetDepartmentById(id);

            }
            else
            {
                viewModel.Id = 0;
            }

            return View(viewModel);


        }

        [HttpPost]
        public async Task<JsonResult> CreateDepartment([FromBody] CategoryDepartmentViewModel model)
        {
            var res = new SaveResultModel<object>();

            res = await categoryService.CreateDepartment(model, User.Identity.Name);
            if (res.LongValReturn == -409)
            {
                res.IsSuccess = false;
                res.ErrorMessage = "Mã bộ phận đã tồn tại!";

            }
            return Json(res);
        }

        [HttpGet]
        public async Task<JsonResult> DeleteDepartment(int Id)
        {
            try
            {
                var rs = await categoryService.DeleteDepartment(Id, AuthenInfo().UserName);
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